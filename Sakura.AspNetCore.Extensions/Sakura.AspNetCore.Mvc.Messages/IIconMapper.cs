using Microsoft.AspNetCore.Html;

namespace Sakura.AspNetCore.Mvc;

/// <summary>
/// Used to map an <see cref="OperationMessageLevel"/> to an icon HTML content.
/// </summary>
public interface IIconMapper
{
    /// <summary>
    /// Get the HTML content for the icon corresponding to the specified operation message level.
    /// </summary>
    /// <param name="level">The operation message level.</param>
    /// <returns>The generated HTML content for <paramref name="level"/>. If the return value is <see langword="null"/>, no icon should be displayed.</returns>
    IHtmlContent? GetIconHtml(OperationMessageLevel level);
}