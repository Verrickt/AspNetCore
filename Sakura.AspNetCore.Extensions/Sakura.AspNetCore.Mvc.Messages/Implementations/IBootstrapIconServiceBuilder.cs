using Microsoft.Extensions.DependencyInjection;

namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Represent as a service builder which may apply Bootstrap icons.
/// </summary>
public interface IBootstrapIconServiceBuilder
{
    /// <summary>
    /// Get the service collection.
    /// </summary>
    IServiceCollection Services { get; }
}