using Application.Videos.Queries;
using Web.Infrastructure;

namespace Web.Endpoints;

public class Video : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapGet(GetHelloWorld);
    }

    private static async Task<string> GetHelloWorld(ISender sender)
    {
        return await sender.Send(new HelloWorldQuery());
    }
}
