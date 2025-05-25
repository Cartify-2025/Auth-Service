using Auth.Application.Logging;
using Microsoft.Extensions.Logging;

namespace Auth.Infrastructure.Logging
{
    public class SerilogAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public SerilogAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Info(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void Warn(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void Error(string message, Exception ex = null, params object[] args)
        {
            _logger.LogError(ex, message, args);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

    }
}
