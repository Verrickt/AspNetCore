using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Sakura.AspNetCore.Mvc.Implementations;
public class Bootstrap5ToastMessageHtmlGenerator(IOperationMessageLevelToStyleMapper styleMapper, IIconMapper iconMapper, IOptions<Bootstrap5ToastMessageHtmlGeneratorOptions> options, IStringLocalizer<Bootstrap5ToastMessageHtmlGeneratorOptions> localizer)
: IOperationMessageHtmlGenerator
{
	/// <inheritdoc />
	public IHtmlContent GenerateList(IEnumerable<OperationMessage> messages, TagHelperContext context)
	{
		var container = new TagBuilder("div");

		// Merge attributes from the context to the container.
		container.MergeAttributes(context.AllAttributes.ToDictionary(i => i.Name, object? (i) => i.Value));
		
		// Fixed class for toast container
		container.AddCssClass("toast-container position-fixed");
		
		// Alignment class
		container.AddCssClasses(GetAlignmentClasses());

		// Container
		foreach (var item in messages)
		{
			container.InnerHtml.AppendHtml(GenerateItem(item));
		}

		return container;
	}

	private IHtmlContent GenerateItem(OperationMessage message)
	{
		var container = new TagBuilder("div")
		{
			Attributes =
			{
				["class"] = "toast fade",
				["role"] = "alert",
				["aria-live"] = "assertive",
				["aria-atomic"] = "true",
				["data-bs-animation"] = options.Value.Animation.ToJavaScriptString(),
				["data-bs-autohide"] = options.Value.AutoHide.ToJavaScriptString(),
				["data-bs-delay"] = options.Value.Delay.TotalMilliseconds.ToString("F")
			}
		};

		var header = new TagBuilder("div")
		{
			Attributes =
			{
				["class"] = "toast-header"
			}
		};


		// strong-styled title
		var titleElement = new TagBuilder("strong")
		{
			Attributes =
			{
				["class"] = "me-auto"
			}
		};

		// Show Icon
		if (options.Value.ShowIcon)
		{
			var iconElement = iconMapper.GetIconHtml(message.Level);

			// Append Icon only if exists
			if (iconElement != null)
			{
				titleElement.InnerHtml.AppendHtml(iconElement).AppendLine();
			}
		}

		// Title
		titleElement.InnerHtml.AppendHtml(message.Title).AppendLine();

		header.InnerHtml.AppendHtml(titleElement);

		// Dismiss button
		if (options.Value.Dismissible)
		{
			var closeButton = new TagBuilder("button")
			{
				Attributes =
				{
					["type"] = "button",
					["class"] = "btn-close",
					["data-bs-dismiss"] = "toast",
					["aria-label"] = localizer[options.Value.DismissAriaLabel]
				}
			};

			header.InnerHtml.AppendHtml(closeButton).AppendLine();
		}

		// Body
		var body = new TagBuilder("div")
		{
			Attributes =
			{
				["class"] = "toast-body"
			}
		};
		body.InnerHtml.AppendHtml(message.Description);

		// Apply style
		var style = styleMapper.GetLevelStyleName(message.Level);
		if (style != null)
		{
			header.AddCssClass($"text-bg-{style}");
			body.AddCssClass($"bg-{style}-subtle text-{style}-emphasis");
		}

		container.InnerHtml.AppendHtml(header).AppendHtml(body);
		return container;
	}

	private IEnumerable<string> GetAlignmentClasses()
	{
		yield return GeneratePositionClassForHorizontalAlignment(options.Value.HorizontalAlignment);
		yield return GeneratePositionClassForVerticalAlignment(options.Value.VerticalAlignment);
	}

	private static string GeneratePositionClassForHorizontalAlignment(HorizontalAlignment value)
	{
		return value switch
		{
			HorizontalAlignment.Left => "start-0",
			HorizontalAlignment.Center => "start-50 translate-middle-x",
			HorizontalAlignment.Right => "end-0",
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, "the value is not a valid enum item.")
		};
	}

	private static string GeneratePositionClassForVerticalAlignment(VerticalAlignment value)
	{
		return value switch
		{
			VerticalAlignment.Top => "top-0",
			VerticalAlignment.Middle => "top-50 translate-middle-y",
			VerticalAlignment.Bottom => "bottom-0",
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, "the value is not a valid enum item.")
		};
	}
}