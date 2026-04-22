using BookCafe.Domain;
using Microsoft.Extensions.Logging;

namespace BookCafe.Infrastructure.Services
{
    public class LogService<TService> : ILogService<TService>
    {
        private readonly ILogger<LogService<TService>> _logger;
        public LogService(ILogger<LogService<TService>> logger)
        {
            _logger = logger;
        }

        public bool LogData<TRequest, TResponse>(LogLevel logLevel, LogData<TRequest, TResponse> logData)
        {
            _logger.Log(logLevel, "Request handled {@LogData}", logData);
            return true;
        }
    }
}
