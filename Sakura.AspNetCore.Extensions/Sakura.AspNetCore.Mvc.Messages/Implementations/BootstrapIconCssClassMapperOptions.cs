namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Used to configure the options for the <see cref="BootstrapIconMapper"/> class.
/// </summary>
public record BootstrapIconCssClassMapperOptions
{
    /// <summary>
    /// Get or set the style of the Bootstrap icon.
    /// </summary>
    public BootstrapIconStyle IconStyle { get; set; } = BootstrapIconStyle.Normal;

    /// <summary>
    /// Get or set whether to use the circle icon for the exclamation mark.
    /// </summary>
    public bool UseCircleForExclamation { get; set; } = false;
}