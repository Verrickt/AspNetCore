namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Provide default implementation for <see cref="IIconToCssClassMapper"/> using Bootstrap icons.
/// </summary>
/// <param name="cssClassMapper"></param>
public class BootstrapIconMapper(IIconToCssClassMapper cssClassMapper)
    : CssClassBasedIconMapper(cssClassMapper)
{
    /// <inheritdoc />
    protected override string? BaseCssClasses { get; } = "bi";
}
