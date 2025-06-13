using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sakura.AspNetCore.Mvc;

/// <summary>
/// Generate HTML content for an icon based on the CSS class name.
/// </summary>
/// <param name="cssClassMapper"></param>
public class CssClassBasedIconMapper(IIconToCssClassMapper cssClassMapper)
    : IIconMapper
{
    /// <summary>
    /// The base css classes for the icon element. Will always be added to the generated HTML tag. 
    /// </summary>
    /// <remarks>This property will be used in the default implementation of <see cref="GenerateBaseTag"/> method.</remarks>
    protected virtual string? BaseCssClasses { get; } = null;

    /// <summary>
    /// The base tag name for the icon element. Default is "i".
    /// </summary>
    /// <remarks>This property will be used in the default implementation of <see cref="GenerateBaseTag"/> method.</remarks>
    protected virtual string BaseTagName { get; } = "i";

    /// <summary>
    /// Generate the HTML tag for the icon element.
    /// </summary>
    /// <returns>The generated <see cref="TagBuilder"/> instance.</returns>
    /// <remarks>The default implementation of this method uses both <see cref="BaseTagName"/> and <see cref="BaseCssClasses"/> during the generation process.</remarks>
    protected virtual TagBuilder GenerateBaseTag()
    {
        var tag = new TagBuilder(BaseTagName);
        tag.AddCssClass(BaseCssClasses ?? string.Empty);

        return tag;
    }

    /// <inheritdoc />
    public IHtmlContent? GetIconHtml(OperationMessageLevel level)
    {
        var iconCssClass = cssClassMapper.GetIconCssClass(level);

        if (iconCssClass is null)
        {
            return null;
        }

        var tag = GenerateBaseTag();
        tag.AddCssClass(iconCssClass);
        return tag;
    }
}