using System;
using System.Diagnostics;
using LoggingLib.Interfaces;
using LoggingLib.Models;
using Microsoft.Extensions.Logging;

namespace LoggingLib
{
    public class Log<T> : ILog<T> where T : class
    {
        private readonly ILogger<T> _logger;
        private readonly EventId _eventId;

        public ApplicationInsightsProperties Properties { get; set; }

        public Log(ILogger<T> logger)
        {
            this._logger = logger;
            this._eventId = new EventId();

            Properties = new ApplicationInsightsProperties
            {
                Entity = typeof(T).Name,
                Method = new StackTrace().GetFrame(1)?.GetMethod()?.Name
            };
        }
       
        public void LogTrace(Exception exception = null)
        {
            _logger.Log(LogLevel.Trace, _eventId, new ApplicationInsightsLog(Properties), exception, FormatMessage);
        }

        public void LogDebug(Exception exception = null)
        {
            _logger.Log(LogLevel.Debug, _eventId, new ApplicationInsightsLog(Properties), exception, FormatMessage);
        }

        public void LogInfo(Exception exception = null)
        {
            _logger.Log(LogLevel.Information, _eventId, new ApplicationInsightsLog(Properties), exception,
                FormatMessage);
        }

        public void LogWarning(Exception exception = null)
        {
            _logger.Log(LogLevel.Warning, _eventId, new ApplicationInsightsLog(Properties), exception, FormatMessage);
        }

        public void LogError(Exception exception = null)
        {
            _logger.Log(LogLevel.Error, _eventId, new ApplicationInsightsLog(Properties), exception, FormatMessage);
        }

        public void LogCritical(Exception exception = null)
        {
            _logger.Log(LogLevel.Critical, _eventId, new ApplicationInsightsLog(Properties), exception, FormatMessage);
        }

        private string FormatMessage(ApplicationInsightsLog log, Exception ex)
        {
            var exceptionMessage = string.Empty;
            if (ex != null)
            {
                exceptionMessage = $" - Exception Message: {ex.Message}";
            }

            return $"{log.Name} - {log.Message}{exceptionMessage}";
        }
    }
}
