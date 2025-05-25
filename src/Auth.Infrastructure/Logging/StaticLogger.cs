using Serilog;

namespace Auth.Infrastructure.Logging
{
    public static class StaticLogger
    {

        public static void Info(string message, params object[] args) =>
            Log.Information(message, args);

        public static void Warn(string message, params object[] args) =>
            Log.Warning(message, args);

        public static void Error(string message, Exception? ex = null, params object[] args)
        {
            if (ex == null)
                Log.Error(message, args);
            else
                Log.Error(ex, message, args);
        }

        public static void Debug(string message, params object[] args) =>
            Log.Debug(message, args);

    }
}
