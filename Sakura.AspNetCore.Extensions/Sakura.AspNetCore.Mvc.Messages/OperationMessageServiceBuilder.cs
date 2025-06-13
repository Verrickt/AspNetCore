using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Framework.DependencyInjection;

/// <summary>
/// Used to configure operation message related services. This class is sealed and cannot be inherited.
/// </summary>
/// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
public sealed class OperationMessageServiceBuilder(IServiceCollection services)
{
    /// <summary>
    /// Get the service collection.
    /// </summary>
    public IServiceCollection Services { get; } = services;
}