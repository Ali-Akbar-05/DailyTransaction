using Application.Abstractions.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

internal sealed class PerformanceBehaviour<TRequest, TResponse> :     IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    private readonly Stopwatch _timer;

    public PerformanceBehaviour(ILogger<TRequest> logger,ICurrentUserService currentUserService,IIdentityService identityService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
        _identityService = identityService;

        _timer =new Stopwatch();
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();

        var elapseMilliSeconds = _timer.ElapsedMilliseconds;

        if(elapseMilliSeconds > 500 )
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;
            string userName = string.Empty;

            if (userId > 0)
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogInformation("DL long running request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName,elapseMilliSeconds,userId, userName,request);

        }
        return response;
    }
}
