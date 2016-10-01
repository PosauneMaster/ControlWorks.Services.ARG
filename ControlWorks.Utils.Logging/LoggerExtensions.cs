using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.Utils.Logging
{
    public static class LoggerExtensions
    {

        public static void Log(this ILogger logger, LoggingEventType eventType, string message)
        {
            logger.Log(new LogEntry(eventType, message));
        }

        public static void Log(this ILogger logger, LoggingEventType eventType, Exception exception)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, exception.Message, exception));
        }

        public static void LogDebug(this ILogger logger, string message)
        {
            Log(logger, LoggingEventType.Debug, message);
        }

        public static void LogDebug(this ILogger logger, Exception exception)
        {
            Log(logger, LoggingEventType.Debug, exception);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            Log(logger, LoggingEventType.Information, message);
        }

        public static void LogInfo(this ILogger logger, Exception exception)
        {
            Log(logger, LoggingEventType.Information, exception);
        }

        public static void LogError(this ILogger logger, string message)
        {
            Log(logger, LoggingEventType.Error, message);
        }

        public static void LogError(this ILogger logger, Exception exception)
        {
            Log(logger, LoggingEventType.Error, exception);
        }

    }
}
