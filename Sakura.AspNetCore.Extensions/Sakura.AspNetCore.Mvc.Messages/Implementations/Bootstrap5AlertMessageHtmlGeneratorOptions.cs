namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Provide options for <see cref="Bootstrap5AlertMessageHtmlGenerator"/>.
/// </summary>
public record  Bootstrap5AlertMessageHtmlGeneratorOptions
{
/// <summary>
    /// Get or set whether an icon should be shown in the message dialog.
    /// </summary>
    public bool ShowIcon { get; set; } = true;

    /// <summary>
    /// Get or set whether the alert message is dismissible (closable).
    /// </summary>
    public bool Dismissible { get; set; } = true;
    /// <summary>
    /// The text used in "aria-label" attribute of the dismiss button in the alert message. This is used for accessibility purposes.
    /// </summary>

    public string DismissAriaLabel { get; set; } = "Close";

    /// <summary>
    /// Get or set the layout of the title and content in the alert message.
    /// </summary>
    public Bootstrap5AlertMessageContentLayout ContentLayout { get; set; } = Bootstrap5AlertMessageContentLayout.SingleRow;
}