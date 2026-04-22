using Microsoft.Extensions.Logging;

namespace BookCafe.Domain
{
    public interface ILogService<TService>
    {
        // ILogger logger { get; }
        bool LogData<TRequest, TResponse>(LogLevel logLevel, LogData<TRequest, TResponse> logData);
    }
}
