using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
///     Provide default implementation for <see cref="IOperationMessageHtmlGenerator" />.
/// </summary>
/// <param name="levelToStyleMapper">The message-level to CSS class mapper.</param>
public class Bootstrap5AlertMessageHtmlGenerator(IOperationMessageLevelToStyleMapper levelToStyleMapper, IIconMapper iconMapper, IOptions<Bootstrap5AlertMessageHtmlGeneratorOptions> options, IStringLocalizer<Bootstrap5AlertMessageHtmlGeneratorOptions> localizer)
	: IOperationMessageHtmlGenerator
{
	/// <inheritdoc />
	public IHtmlContent GenerateList(IEnumerable<OperationMessage> messages, TagHelperContext context)
	{
		var container = new TagBuilder("div");
		container.MergeAttributes(context.AllAttributes.ToDictionary(i => i.Name, object? (i) => i.Value));
		
		foreach (var message in messages)
		{
			var alertItem = GenerateAlertItem(message);
			if (alertItem != null)
			{
				container.InnerHtml.AppendHtml(alertItem);
			}
		}

		return container;
	}

	/// <summary>
	///     Generate the alert dialog for a <see cref="OperationMessage" />.
	/// </summary>
	/// <param name="message">The <see cref="OperationMessage" /> instance.</param>
	/// <returns>The generated HTML content which represent as a HTML alert dialog.</returns>
	private IHtmlContent? GenerateAlertItem(OperationMessage message)
	{
		// Get the base style.
		var baseStyle = levelToStyleMapper.GetLevelStyleName(message.Level);

		// No base style means no alert dialog should be generated.
		if (baseStyle == null)
		{
			return null;
		}

		var container = new TagBuilder("div")
		{
			Attributes =
			{
				["role"] = "alert"
			}
		};

		container.AddCssClass($"alert alert-{baseStyle}");
		if (options.Value.Dismissible)
		{
			container.AddCssClass("alert-dismissible fade show");
		}

		if (options.Value.ShowIcon)
		{
			// The icon should be shown in the alert dialog.
			var iconHtml = iconMapper.GetIconHtml(message.Level);

			if (iconHtml != null)
			{
				container.InnerHtml.AppendHtml(iconHtml).AppendLine();
			}
		}

		if (message.Title != null)
		{
			var titleElement = new TagBuilder("strong");
			titleElement.InnerHtml.AppendHtml(message.Title);

			container.InnerHtml.AppendHtml(titleElement).AppendLine();
		}

		// separator, only show if both title and description exist.
		if (message is { Title: not null, Description: not null })
		{
			var separator = GenerateSeparator(options.Value.ContentLayout);
			container.InnerHtml.AppendHtml(separator);
		}

		if (message.Description != null)
		{
			container.InnerHtml.AppendHtml(message.Description).AppendLine();
		}

		if (options.Value.Dismissible)
		{
			var closeButton = new TagBuilder("button")
			{
				Attributes =
				{
					["class"] = "btn-close",
					["type"] = "button",
					["data-bs-dismiss"] = "alert",
					["aria-label"] = localizer[options.Value.DismissAriaLabel]
				}
			};

			container.InnerHtml.AppendHtml(closeButton).AppendLine();
		}

		return container;
	}

	/// <summary>
	/// Generate the separator HTML content based on the specified layout.
	/// </summary>
	/// <param name="layout">The layout used of the alert message.</param>
	/// <returns>The separator HTML content.</returns>
	/// <exception cref="ArgumentOutOfRangeException">The <paramref name="layout"/> is not a valid enum item.</exception>
	private static IHtmlContent GenerateSeparator(Bootstrap5AlertMessageContentLayout layout)
	{
		var htmlString = layout switch
		{
			Bootstrap5AlertMessageContentLayout.SingleRow => " ",
			Bootstrap5AlertMessageContentLayout.DoubleRow => "<br />",
			Bootstrap5AlertMessageContentLayout.DoubleRowWithSeparator => "<hr />",
			_ => throw new ArgumentOutOfRangeException(nameof(layout), layout, "The argument is not a valid enum item.")
		};

		return new HtmlString(htmlString);
	}

}