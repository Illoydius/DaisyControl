using System;
using System.Windows.Media.Imaging;
using DaisyControl.Client.DaisyConnect.Managers;
using DaisyControl.Common.DaisyUtils;

namespace DaisyControl.Client.DaisyConnect.Utils
{
    internal static class ImageUtils
    {
        // ********************************************************************
        //                            Internal
        // ********************************************************************
        /// <summary>
        /// Load an image from disk with validations and convert it to BitmapImage
        /// </summary>
        /// <param name="aImagePath"></param>
        /// <returns></returns>
        internal static BitmapImage GetBitmapImageFromImageOnDisk(string aImagePath)
        {
            if (!FileUtils.CheckIfFileExistsOnDisk(aImagePath))
                ErrorManager.RegisterNewError("DE5B4646-373D-49FA-8A8E-1A91094A3FCC", $"File [{aImagePath}] wasn't found.", aExitApplicationAfterMessage: true);

            BitmapImage _Image = null;

            try
            {
                _Image = new BitmapImage(new Uri($"{Environment.CurrentDirectory}\\{aImagePath}"));
            } catch (Exception _Ex)
            {
                ErrorManager.RegisterNewError("CBD30AE6-40EA-4759-AF46-69AC89D40813", $"Image [{aImagePath}] is invalid or corrupted.", _Ex, aExitApplicationAfterMessage: true);
            }

            return _Image;
        }
    }
}
