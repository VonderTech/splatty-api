using System.Diagnostics.CodeAnalysis;

namespace Web.Infrastructure;

/// <summary>
///     Provides extension methods for the IEndpointRouteBuilder interface.
/// </summary>
public static class EndpointRouteBuilderExtensions
{
    /// <summary>
    ///     Maps a GET request to the specified delegate.
    /// </summary>
    /// <param name="builder">The IEndpointRouteBuilder to add the route to.</param>
    /// <param name="handler">The delegate to execute when the route is matched.</param>
    /// <param name="pattern">The route pattern.</param>
    /// <returns>The same IEndpointRouteBuilder, for chaining calls.</returns>
    public static IEndpointRouteBuilder MapGet(
        this IEndpointRouteBuilder builder,
        Delegate handler,
        [StringSyntax("Route")] string pattern = ""
    )
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapGet(pattern, handler).WithName(handler.Method.Name);

        return builder;
    }

    /// <summary>
    ///     Maps a POST request to the specified delegate.
    /// </summary>
    /// <param name="builder">The IEndpointRouteBuilder to add the route to.</param>
    /// <param name="handler">The delegate to execute when the route is matched.</param>
    /// <param name="pattern">The route pattern.</param>
    /// <returns>The same IEndpointRouteBuilder, for chaining calls.</returns>
    public static IEndpointRouteBuilder MapPost(
        this IEndpointRouteBuilder builder,
        Delegate handler,
        [StringSyntax("Route")] string pattern = ""
    )
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapPost(pattern, handler).WithName(handler.Method.Name);

        return builder;
    }

    /// <summary>
    ///     Maps a PUT request to the specified delegate.
    /// </summary>
    /// <param name="builder">The IEndpointRouteBuilder to add the route to.</param>
    /// <param name="handler">The delegate to execute when the route is matched.</param>
    /// <param name="pattern">The route pattern.</param>
    /// <returns>The same IEndpointRouteBuilder, for chaining calls.</returns>
    public static IEndpointRouteBuilder MapPut(
        this IEndpointRouteBuilder builder,
        Delegate handler,
        [StringSyntax("Route")] string pattern
    )
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapPut(pattern, handler).WithName(handler.Method.Name);

        return builder;
    }

    /// <summary>
    ///     Maps a DELETE request to the specified delegate.
    /// </summary>
    /// <param name="builder">The IEndpointRouteBuilder to add the route to.</param>
    /// <param name="handler">The delegate to execute when the route is matched.</param>
    /// <param name="pattern">The route pattern.</param>
    /// <returns>The same IEndpointRouteBuilder, for chaining calls.</returns>
    public static IEndpointRouteBuilder MapDelete(
        this IEndpointRouteBuilder builder,
        Delegate handler,
        [StringSyntax("Route")] string pattern
    )
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapDelete(pattern, handler).WithName(handler.Method.Name);

        return builder;
    }
}
