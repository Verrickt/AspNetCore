using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Framework.DependencyInjection;

namespace Sakura.AspNetCore.Mvc.Implementations;



/// <summary>
/// Provide extension methods for configuring Bootstrap-style messages in ASP.NET Core applications.
/// </summary>
public static class BootstrapBuilderExtensions
{
    /// <summary>
    /// Use the Bootstrap 5 alert messages as the operation message UI implementation.
    /// </summary>
    /// <param name="serviceBuilder">The <see cref="OperationMessageServiceBuilder"/> instance.</param>
    /// <param name="configAction">Optional action for configure the <see cref="Bootstrap5AlertMessageHtmlGeneratorOptions"/>.</param>
    /// <returns>The <see cref="Bootstrap5MessagesServiceBuilder"/> instance which can be used to further configure related services.</returns>
    public static Bootstrap5MessagesServiceBuilder UseBootstrap5Alerts(this OperationMessageServiceBuilder serviceBuilder, Action<Bootstrap5AlertMessageHtmlGeneratorOptions>? configAction = null)
    {
        serviceBuilder.Services.TryAddSingleton<IOperationMessageHtmlGenerator, Bootstrap5AlertMessageHtmlGenerator>();
        serviceBuilder.Services.TryAddSingleton<IOperationMessageLevelToStyleMapper, DefaultBootstrap5OperationMessageLevelToStyleMapper>();

        if (configAction != null)
        {
            serviceBuilder.Services.Configure(configAction);
        }

        return new (serviceBuilder.Services);
    }

    /// <summary>
    /// Use the Bootstrap 5 alert messages as the operation message UI implementation.
    /// </summary>
    /// <param name="serviceBuilder">The <see cref="OperationMessageServiceBuilder"/> instance.</param>
    /// <param name="configAction">Optional action for configure the <see cref="Bootstrap5AlertMessageHtmlGeneratorOptions"/>.</param>
    /// <returns>The <see cref="Bootstrap5MessagesServiceBuilder"/> instance which can be used to further configure related services.</returns>
    public static Bootstrap5MessagesServiceBuilder UseBootstrap5Toasts(this OperationMessageServiceBuilder serviceBuilder, Action<Bootstrap5ToastMessageHtmlGeneratorOptions>? configAction = null)
    {
        serviceBuilder.Services.TryAddSingleton<IOperationMessageHtmlGenerator, Bootstrap5ToastMessageHtmlGenerator>();
        serviceBuilder.Services.TryAddSingleton<IOperationMessageLevelToStyleMapper, DefaultBootstrap5OperationMessageLevelToStyleMapper>();

        if (configAction != null)
        {
            serviceBuilder.Services.Configure(configAction);
        }

        return new(serviceBuilder.Services);
    }

    /// <summary>
    /// Use the bootstrap icons for the Bootstrap 5 alert messages.
    /// </summary>
    /// <param name="builder">The <see cref="Bootstrap5MessagesServiceBuilder"/> instance.</param>
    /// <param name="configAction">Optional action for configure the <see cref="BootstrapIconCssClassMapperOptions"/>.</param>
    public static void UseBootstrapIcons(this IBootstrapIconServiceBuilder builder, Action<BootstrapIconCssClassMapperOptions>? configAction = null)
    {
        builder.Services.TryAddSingleton<IIconMapper, BootstrapIconMapper>();
        builder.Services.TryAddSingleton<IIconToCssClassMapper, DefaultBootstrapIconCssClassMapper>();

        if (configAction != null)
        {
            builder.Services.Configure(configAction);
        }
    }
}