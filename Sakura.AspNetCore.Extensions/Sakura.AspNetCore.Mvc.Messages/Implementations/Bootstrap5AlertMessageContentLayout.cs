namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Control the layout of the title and content in a Bootstrap 5 alert message.
/// </summary>
public enum Bootstrap5AlertMessageContentLayout
{
    /// <summary>
    /// The title and content is displayed in a single row.
    /// </summary>
    SingleRow,
    /// <summary>
    /// The title and content is displayed in two rows, without a separator between them.
    /// </summary>
    DoubleRow,
    /// <summary>
    /// The title and content is displayed in two rows, with a separator between them. Note if either of them is empty, the separator will not be shown.
    /// </summary>
    DoubleRowWithSeparator,
}