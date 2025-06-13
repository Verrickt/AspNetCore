using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sakura.AspNetCore;
using Sakura.AspNetCore.Mvc;
using Sakura.AspNetCore.Mvc.Implementations;

// ReSharper disable once CheckNamespace

namespace Microsoft.Framework.DependencyInjection;

/// <summary>
///     Provide extension methods for service injection. This class is static.
/// </summary>
[PublicAPI]
public static class ServiceCollectionExtensions
{
	/// <summary>
	///     Add operation messages and all related services.
	/// </summary>
	/// <param name="services">The <see cref="IServiceCollection" /> object.</param>
	/// <param name="setupAction">Optional setup actions.</param>
	public static OperationMessageServiceBuilder AddOperationMessages(this IServiceCollection services,
		Action<OperationMessageOptions>? setupAction = null)
	{
		services.AddOperationMessageAccessor(setupAction);
		return new (services);
	}
}