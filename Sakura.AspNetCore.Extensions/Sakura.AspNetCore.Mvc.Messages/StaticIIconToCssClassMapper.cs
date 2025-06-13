using System.Collections.Frozen;
using System.Collections.Generic;

namespace Sakura.AspNetCore.Mvc;

/// <summary>
/// Provide static mapping between <see cref="OperationMessageLevel"/> and CSS class names for icons.
/// </summary>
/// <param name="mappings">The mapping dictionary.</param>
public class StaticIIconToCssClassMapper(IReadOnlyDictionary<OperationMessageLevel, string> mappings) 
    : IIconToCssClassMapper
{
    /// <summary>
    /// Internal frozen dictionary to store the mappings between <see cref="OperationMessageLevel"/> and CSS class names.
    /// </summary>
    private FrozenDictionary<OperationMessageLevel, string> Mappings { get; } = mappings.ToFrozenDictionary();

    /// <inheritdoc />
    public string? GetIconCssClass(OperationMessageLevel level)
    {
        return Mappings.GetValueRefOrNullRef(level);
    }
}