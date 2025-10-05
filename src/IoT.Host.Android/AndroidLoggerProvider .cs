using System;
using Microsoft.Extensions.Logging;
using Android.Util;

namespace IoT.Host.Android;

public class AndroidLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new AndroidLogger(categoryName);

    public void Dispose() { }

    private class AndroidLogger : ILogger
    {
        private readonly string _tag;

        public AndroidLogger(string categoryName)
        {
            // Android logcat max is 23 chars
            _tag = categoryName.Length > 23 ? categoryName[..23] : categoryName;
        }

        IDisposable ILogger.BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception? exception, 
            Func<TState, Exception?, string> formatter
        )
        {
            var message = formatter(state, exception);

            if (exception != null)
                message += Environment.NewLine + exception;

            switch (logLevel)
            {
                case LogLevel.Trace:
                    global::Android.Util.Log.Verbose(_tag, message);
                    break;
                case LogLevel.Debug:
                    global::Android.Util.Log.Debug(_tag, message);
                    break;
                case LogLevel.Information:
                    global::Android.Util.Log.Info(_tag, message);
                    break;
                case LogLevel.Warning:
                    global::Android.Util.Log.Warn(_tag, message);
                    break;
                case LogLevel.Error:
                    global::Android.Util.Log.Error(_tag, message);
                    break;
                case LogLevel.Critical:
                    global::Android.Util.Log.Wtf(_tag, message); // "What a Terrible Failure" – Android's fatal level
                    break;
                case LogLevel.None:
                default:
                    // Do nothing
                    break;
            }

        }
    }
}
