using Microsoft.Extensions.Options;

namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Provide the default implementation of <see cref="IIconToCssClassMapper"/> for Bootstrap icons.
/// </summary>
/// <param name="options">The options for icon mapping.</param>
public class DefaultBootstrapIconCssClassMapper(IOptions<BootstrapIconCssClassMapperOptions> options)
    : IIconToCssClassMapper
{
    /// <inheritdoc />
    public string? GetIconCssClass(OperationMessageLevel level)
    {
        var baseClass = level switch
        {
            OperationMessageLevel.Success => "check-circle",
            OperationMessageLevel.Warning => options.Value.UseCircleForExclamation
                ? "exclamation-circle"
                : "exclamation-triangle",
            OperationMessageLevel.Info => "info-circle",
            OperationMessageLevel.Error => "x-circle",
            _ => null
        };

        // No icon for unclassified or debug/verbose levels
        if (baseClass is null)
        {
            return null;
        }

        return options.Value.IconStyle switch
        {
            BootstrapIconStyle.Normal => $"bi-{baseClass}",
            BootstrapIconStyle.Filled => $"bi-{baseClass}-fill",
            _ => null
        };
    }
}