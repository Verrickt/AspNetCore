namespace Sakura.AspNetCore.Mvc;

/// <summary>
///     Provide methods to convert <see cref="OperationMessageLevel" /> into primary style names. The style names may be used to generate CSS classes for displaying operation messages in a web application.
/// </summary>
public interface IOperationMessageLevelToStyleMapper
{
	/// <summary>
	///     Get base style name of a <see cref="OperationMessageLevel" />.
	/// </summary>
	/// <param name="level">The level of an operation message.</param>
	/// <returns>The base style of the <paramref name="level"/>. Returns <see langword="null"/> if no style should be applied.</returns>
	string? GetLevelStyleName(OperationMessageLevel level);
}