using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sakura.AspNetCore.Mvc;

/// <summary>
///     Provide tag helper service for messages.
/// </summary>
/// <param name="messageAccessor">The <see cref="IOperationMessageAccessor"/> service.</param>
/// <param name="generator">The <see cref="IOperationMessageHtmlGenerator"/> service.</param>
[HtmlTargetElement(TagName)]
public class MessageTagHelper(IOperationMessageAccessor messageAccessor, IOperationMessageHtmlGenerator generator)
	: TagHelper
{
	/// <summary>
	/// The tag name of this tag helper. This field is constant.
	/// </summary>
	[PublicAPI]
	public const string TagName = "operation-message-list";

	/// <summary>
	///     Synchronously executes the <see cref="TagHelper" /> with the given <paramref name="context" /> and
	///     <paramref name="output" />.
	/// </summary>
	/// <param name="context">Contains information associated with the current HTML tag.</param>
	/// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
	// Generate the output
		var tag = generator.GenerateList(messageAccessor.Messages, context);

		// Dismiss current tag
		output.TagName = null;
		// Append content
		output.PostContent.AppendHtml(tag);
	}
}