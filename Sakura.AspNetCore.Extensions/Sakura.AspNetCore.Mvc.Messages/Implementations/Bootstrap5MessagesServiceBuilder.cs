using Microsoft.Extensions.DependencyInjection;

namespace Sakura.AspNetCore.Mvc.Implementations;

/// <summary>
/// Used to configure the Bootstrap 5 alert messages service.
/// </summary>
/// <param name="service">The <see cref="IServiceCollection"/> instance.</param>
public sealed class Bootstrap5MessagesServiceBuilder(IServiceCollection service)
 : IBootstrapIconServiceBuilder
{
    /// <summary>
    /// Get the service collection.
    /// </summary>
    public IServiceCollection Services { get; } = service;
}