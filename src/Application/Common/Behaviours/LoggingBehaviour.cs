using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

/// <summary>
///     Represents a logging behavior that logs information about requests.
///     This class is a part of the MediatR pipeline and is executed before the request handler.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="LoggingBehaviour{TRequest}" /> class.
    /// </summary>
    /// <param name="logger">The logger used to log information.</param>
    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     Processes the request before it is handled.
    ///     Logs the name of the request and the request itself.
    /// </summary>
    /// <param name="request">The request to process.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Splatty Request: {Name} {@Request}", requestName, request);
        return Task.CompletedTask;
    }
}
