namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Provides the default implementation of <see cref="IOperationMessageLevelToStyleMapper"/>.
/// </summary>
public class DefaultBootstrap5OperationMessageLevelToStyleMapper : IOperationMessageLevelToStyleMapper
{
    /// <inheritdoc />
    public string? GetLevelStyleName(OperationMessageLevel level)
    {
        return level switch
        {
            OperationMessageLevel.Success => "success",
            OperationMessageLevel.Warning => "warning",
            OperationMessageLevel.Error or OperationMessageLevel.Critical => "danger",
            OperationMessageLevel.Info => "info",
            OperationMessageLevel.Debug or OperationMessageLevel.Verbose => "secondary",
             _ => null,
        };
    }
}