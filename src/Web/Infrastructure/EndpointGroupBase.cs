namespace Web.Infrastructure;

/// <summary>
///     Represents the base class for endpoint groups.
/// </summary>
public abstract class EndpointGroupBase
{
    /// <summary>
    ///     Maps the endpoints of the group to the specified web application.
    /// </summary>
    /// <param name="app">The web application to which the endpoints are mapped.</param>
    public abstract void Map(WebApplication app);
}
