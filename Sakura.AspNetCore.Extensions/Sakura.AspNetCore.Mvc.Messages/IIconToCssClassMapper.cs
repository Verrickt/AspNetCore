using System.Runtime.InteropServices.ComTypes;

namespace Sakura.AspNetCore.Mvc;

/// <summary>
/// Used to map an <see cref="OperationMessageLevel"/> to a CSS class name for an icon.
/// </summary>
public interface IIconToCssClassMapper
{
    /// <summary>
    /// Try to get the CSS class name for the icon based on the operation message level.
    /// </summary>
    /// <param name="level">The operation message level.</param>
    /// <returns>The CSS class for the <see cref="level"/>. <see langword="null"/> return value means no icon should be generated. </returns>
    string? GetIconCssClass(OperationMessageLevel level);
}