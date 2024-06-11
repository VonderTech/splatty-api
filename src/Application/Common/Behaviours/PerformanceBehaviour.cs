using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

/// <summary>
///     Represents a performance behavior that logs long running requests.
///     This class is a part of the MediatR pipeline and is executed during the handling of a request.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly Stopwatch _timer;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PerformanceBehaviour{TRequest, TResponse}" />
    ///     class.
    /// </summary>
    /// <param name="logger">The logger used to log information.</param>
    public PerformanceBehaviour(ILogger<PerformanceBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
        _timer = new Stopwatch();
    }

    /// <summary>
    ///     Handles the request and logs if the request takes more than 500 milliseconds to complete.
    /// </summary>
    /// <param name="request">The request to handle.</param>
    /// <param name="next">The next delegate in the pipeline.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the response
    ///     from the request.
    /// </returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500)
            return response;
        var requestName = typeof(TRequest).Name;

        _logger.LogWarning(
            "Splatty Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
            requestName,
            elapsedMilliseconds,
            request
        );

        return response;
    }
}
