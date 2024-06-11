using System.Reflection;
using Application.Common.Behaviours;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
///     Provides extension methods for <see cref="IServiceCollection" /> to add application services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Adds application services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            // Register services from the current assembly
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            // Add LoggingBehaviour as a pre-processor for all requests
            cfg.AddRequestPreProcessor(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviour<>));

            // Add UnhandledExceptionBehaviour as a pipeline behavior for all requests
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            // Add PerformanceBehaviour as a pipeline behavior for all requests
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        return services;
    }
}
