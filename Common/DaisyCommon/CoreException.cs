using System;

namespace DaisyControl.Common.DaisyCommon
{
    /// <summary>
    /// Parent Exception Class
    /// </summary>
    public class CoreException : Exception
    {
        // ********************************************************************
        // *                        Const
        // ********************************************************************
        protected const string ELEMENTS_SEPARATOR = ": ";

        // ********************************************************************
        // *                        Inner Types
        // ********************************************************************
        public CoreException() { }

        public CoreException(object aCallerType, string aCode, string aMessage, params object[] aParameters)
                : base(FormatMessage(aCallerType, null, aCode, aMessage, aParameters))
        {
            this.Code = aCode;
            this.FormattedMessage = FormatMessage(aCallerType, null, aCode, aMessage, aParameters);
            this.RawMessage = string.Format(aMessage, aParameters);
        }

        public CoreException(object aCallerType, Exception aException, string aCode, string aMessage, params object[] aParameters)
                : base(FormatMessage(aCallerType, aException, aCode, aMessage, aParameters), aException)
        {
            this.Code = aCode;
            this.FormattedMessage = FormatMessage(aCallerType, aException, aCode, aMessage, aParameters);
            this.RawMessage = string.Format(aMessage, aParameters);
        }

        // ********************************************************************
        //                         Private
        // ********************************************************************
        private static string GetFormattedCodeAndMessage(string aCode, string aMessage, params object[] aParameters)
        {
            string _Message = aMessage;

            if (aParameters != null)
                _Message = string.Format(aMessage, aParameters);

            return $"[{aCode}] - {_Message}";
        }

        // ********************************************************************
        // *                        Public
        // ********************************************************************
        public static string FormatMessage(object aCaller, Exception aException, string aCode, string aMessage, params object[] aParameters)
        {
            string _FullName = aCaller?.GetType()?.FullName;

            if (aCaller is Type _Type)
                _FullName = _Type?.FullName;

            if (aException == null)
                return $@"{DateTime.Now.ToString(DateConstants.COMMON_DATE_FORMAT)}{ELEMENTS_SEPARATOR}{_FullName} {GetFormattedCodeAndMessage(aCode, aMessage, aParameters)}{Environment.NewLine}";

            return $@"{DateTime.Now.ToString(DateConstants.COMMON_DATE_FORMAT)}{ELEMENTS_SEPARATOR}{_FullName} {GetFormattedCodeAndMessage(aCode, aMessage, aParameters)} Exception Message=[{aException.Message}] {Environment.NewLine} Exception StackTrace=[{aException.StackTrace}] {Environment.NewLine} Inner Exception=[{aException.InnerException}] {Environment.NewLine}";
        }

        // ********************************************************************
        //                         Properties
        // ********************************************************************
        public string Code { get; set; }
        public string FormattedMessage { get; set; }
        public string RawMessage { get; set; }
    }
}
