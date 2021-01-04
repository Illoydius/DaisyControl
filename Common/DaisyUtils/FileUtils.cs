using System.IO;

namespace DaisyControl.Common.DaisyUtils
{
    public static class FileUtils
    {
        // ********************************************************************
        //                            Public
        // ********************************************************************
        public static bool CheckIfFileExistsOnDisk(string aFilePath)
        {
            return File.Exists(aFilePath);
        }
    }
}
