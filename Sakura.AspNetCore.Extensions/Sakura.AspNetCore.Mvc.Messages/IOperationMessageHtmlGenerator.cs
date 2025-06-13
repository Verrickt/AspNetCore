using System.Collections.Generic;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sakura.AspNetCore.Mvc;

/// <summary>
///     Define the necessary feature for generating HTML content for <see cref="OperationMessage" /> list.
/// </summary>
public interface IOperationMessageHtmlGenerator
{
	/// <summary>
	///     Generate HTML content for one or more <see cref="OperationMessage" /> objects.
	/// </summary>
	/// <param name="messages">The list of message to generating the HTML content.</param>
	/// <param name="context">The context of the <see cref="TagHelper"/>.</param>
	/// <returns>The generated <see cref="IHtmlContent"/>.</returns>
	IHtmlContent GenerateList(IEnumerable<OperationMessage> messages, TagHelperContext context);
}