using System;
using System.IO;

namespace DaisyControl.Common.DaisyCommon.Managers
{
    public static class LogManager
    {
        // ********************************************************************
        //                            Constants
        // ********************************************************************
        private const string FILE_LOG_NAME = "diagnostics.log";

        // ********************************************************************
        //                            Private
        // ********************************************************************
        private static string FindExceptionLogMessageFromException(Exception aException)
        {
            string _InnerMessage = "";

            if (aException.InnerException != null)
                _InnerMessage = FindExceptionLogMessageFromException(aException.InnerException);

            return $"{aException.Message} StackTrace=[{aException.StackTrace}]. {_InnerMessage}";
        }

        private static string FormatMessage(string aCode, string aRawMessage) => $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}] {aCode} - {aRawMessage}{Environment.NewLine}";

        // ********************************************************************
        //                            Public
        // ********************************************************************
        public static void LogToFile(string aCode, string aMessage, Exception aException = null)
        {
            if (aException != null)
                aMessage += $"InnerException = [{FindExceptionLogMessageFromException(aException)}].";

            aMessage = FormatMessage(aCode, aMessage);

            File.AppendAllText(FILE_LOG_NAME, aMessage);
        }
    }
}
