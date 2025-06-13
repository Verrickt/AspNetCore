using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Provide utility methods. This class is static.
/// </summary>
internal static class Utility
{
	/// <summary>
	/// Execute the specified action for each item in the <see cref="IEnumerable{T}"/> source.
	/// </summary>
	/// <typeparam name="T">The element type of the <paramref name="source"/>.</typeparam>
	/// <param name="source">The source collection.</param>
	/// <param name="action">The action to be performed on each item of the <paramref name="source"/>.</param>
	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		foreach (var item in source)
		{
			action(item);
		}
	}
	
	/// <summary>
	/// Adds multiple CSS classes to the specified <see cref="TagBuilder"/> instance.
	/// </summary>
	/// <param name="tag">The <see cref="TagBuilder"/> instance.</param>
	/// <param name="cssClassList">The collection of CSS classes to be adding.</param>
	public static void AddCssClasses(this TagBuilder tag, params IEnumerable<string> cssClassList)
	{
		cssClassList.ForEach(tag.AddCssClass);
	}

	/// <summary>
	/// Convert the <see cref="bool"/> value to a JavaScript string representation.
	/// </summary>
	/// <param name="value">The value to be converted.</param>
	/// <returns>The converted JavaScript value representation for <paramref name="value"/>.</returns>
	public static string ToJavaScriptString(this bool value) =>
		value ? "true" : "false";
}
