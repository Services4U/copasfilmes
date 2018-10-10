using Serilog;
using System;
using System.Threading;

namespace CopaFilmes.Infrastructure.CrossCutting.Logs
{
    public static class Log
    {
        private static ILogger _log;

        public static void Register(ILogger log) =>
            _log = log;

        public static void Information(string message) =>
            _log.Information(message);

        public static void Information(string message, params object[] values) =>
            _log.Information(message, values);

        public static void Debug(string message) =>
            _log.Debug(message);

        public static void Debug(string message, params object[] values) =>
            _log.Debug(message, values);

        public static void Error(Exception ex, string message = "") =>
            _log.Error(ex, message);

        public static void Error(Exception ex, string message = "", params object[] values) =>
            _log.Error(ex, message, values);

        public static void Fatal(string message) =>
           _log.Fatal("", message);

        public static void Verbose(string message) =>
            _log.Verbose(message);

        public static void Verbose(string message, params object[] values) =>
            _log.Verbose(message, values);

        public static async void VerboseAsync(string message) =>
            ThreadPool.QueueUserWorkItem(delegate
            {
                Thread.Sleep(1000);
                _log.Verbose("Async {message}", message);
            }, null);
    }
}
