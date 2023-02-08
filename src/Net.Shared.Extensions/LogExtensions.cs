using Microsoft.Extensions.Logging;

using Net.Shared.Exceptions;

namespace Net.Shared.Extensions;

public static class LogExtensions
{
    private static readonly string Pattern = "[{time:dd-MM HH:mm:ss}] - {message}";

    private static readonly Action<ILogger, DateTime, string, Exception?> Error = LoggerMessage.Define<DateTime, string>(LogLevel.Error, LogEvents.Error, Pattern);
    private static readonly Action<ILogger, DateTime, string, Exception?> Warning = LoggerMessage.Define<DateTime, string>(LogLevel.Warning, LogEvents.Warning, Pattern);
    private static readonly Action<ILogger, DateTime, string, Exception?> Information = LoggerMessage.Define<DateTime, string>(LogLevel.Information, LogEvents.Information, Pattern);
    private static readonly Action<ILogger, DateTime, string, Exception?> Debug = LoggerMessage.Define<DateTime, string>(LogLevel.Debug, LogEvents.Debug, Pattern);
    private static readonly Action<ILogger, DateTime, string, Exception?> Trace = LoggerMessage.Define<DateTime, string>(LogLevel.Trace, LogEvents.Trace, Pattern);


    public static void LogError(this ILogger logger, NetSharedException exception) => Error(logger, DateTime.UtcNow, exception.Message, null);
    public static void LogWarn(this ILogger logger, string message) => Warning(logger, DateTime.UtcNow, message, null);
    public static void LogInfo(this ILogger logger, string message) => Information(logger, DateTime.UtcNow, message, null);
    public static void LogDebug(this ILogger logger, string message) => Debug(logger, DateTime.UtcNow, message, null);
    public static void LogTrace(this ILogger logger, string message) => Trace(logger, DateTime.UtcNow, message, null);

    private static class LogEvents
    {
        public static readonly EventId Error = new(1000, "error native log");
        public static readonly EventId Warning = new(1001, "warning native log");
        public static readonly EventId Information = new(1002, "information native log");
        public static readonly EventId Debug = new(1003, "debug native log");
        public static readonly EventId Trace = new(1004, "trace native log");
    }
}