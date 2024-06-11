using System.Reflection;

namespace Web.Infrastructure;

/// <summary>
///     Provides extension methods for the WebApplication class.
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    ///     Maps a group of endpoints to the web application.
    /// </summary>
    /// <param name="app">The web application to which the endpoints are mapped.</param>
    /// <param name="group">The group of endpoints to map.</param>
    /// <returns>A RouteGroupBuilder that can be used to further configure the route group.</returns>
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name;

        return app.MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    /// <summary>
    ///     Maps all endpoint groups found in the executing assembly to the web application.
    /// </summary>
    /// <param name="app">The web application to which the endpoints are mapped.</param>
    /// <returns>The same web application, for chaining calls.</returns>
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly
            .GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
                instance.Map(app);

        return app;
    }
}
