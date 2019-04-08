using System;
using LoggingLib.Models;

namespace LoggingLib.Interfaces
{
    public interface ILog<T> where T : class
    {
        ApplicationInsightsProperties Properties { get; set; }

        void LogTrace(Exception exception = null);

        void LogDebug(Exception exception = null);

        void LogInfo(Exception exception = null);

        void LogWarning(Exception exception = null);

        void LogError(Exception exception = null);

        void LogCritical(Exception exception = null);
    }
}