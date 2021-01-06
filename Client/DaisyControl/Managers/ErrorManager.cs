using System;
using System.Windows;
using DaisyControl.Common.DaisyCommon.Managers;

namespace DaisyControl.Client.DaisyConnect.Managers
{
    internal static class ErrorManager
    {
        // ********************************************************************
        //                            Internal
        // ********************************************************************
        internal static void RegisterNewError(string aCode, string aMessage, Exception aException = null, bool aShowMessageBox = true, bool aExitApplicationAfterMessage = false)
        {
            // Log first
            LogManager.LogToFile(aCode, aMessage, aException);

            // Show messageBox if required
            if (aShowMessageBox)
                MessageBox.Show($"{aMessage} - Please check logs for more details.", "Error");
        }
    }
}
