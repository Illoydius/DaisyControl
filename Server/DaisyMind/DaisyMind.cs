using System.IO;
using DaisyControl.Common.DaisyCommon.Serialization;
using DaisyControl.Server.DaisyMind.Modules.Memory;

namespace DaisyControl.Server.DaisyMind
{
    public class DaisyMind
    {
        // ********************************************************************
        //                            Constants
        // ********************************************************************
        private const string SAVE_FILE_PATH = "Storage";

        // ********************************************************************
        //                            Constructors
        // ********************************************************************
        public DaisyMind()
        {
            // For serialization purpose
        }

        public DaisyMind(string aDaisyMindSaveFileName, DaisyMindGenerationConfig aDaisyMindGenerationConfig)
        {
            SaveFileName = aDaisyMindSaveFileName;

            if (File.Exists(GetFileSavePath()))
                ReloadMind();
            else
            {
                GenerateNewMind(aDaisyMindGenerationConfig);
                SaveMind();
            }
        }

        // ********************************************************************
        //                            Private
        // ********************************************************************

        private void GenerateNewMind(DaisyMindGenerationConfig aDaisyMindGenerationConfig)
        {
            this.Memory = new DaisyMindMemoryModel();
        }

        // ********************************************************************
        //                            Public
        // ********************************************************************
        public DaisyMindMemoryModel GetCopyOfMemory()
        {
            string _SerializedValue = JsonSerializer.SerializeToString(this.Memory);
            DaisyMindMemoryModel _CopyOfMemory = JsonSerializer.DeserializeFromString<DaisyMindMemoryModel>(_SerializedValue);
            return _CopyOfMemory;
        }

        public string GetFileSavePath()
        {
            return Path.Combine(SAVE_FILE_PATH, SaveFileName);
        }

        public void ReloadMind(bool aSaveBeforeReload = true)
        {
            if (aSaveBeforeReload)
                SaveMind();

            string a = File.ReadAllText(GetFileSavePath());
            DaisyMind b = JsonSerializer.DeserializeFromString<DaisyMind>(a);

            DaisyMind _TempMind = JsonSerializer.DeserializeFromFileWithDefaultValue<DaisyMind>(GetFileSavePath());
            Memory = _TempMind.Memory;
            SaveFileName = _TempMind.SaveFileName;
        }

        public void SaveMind()
        {
            JsonSerializer.SerializeToFile(GetFileSavePath(), this, true);
        }

        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public DaisyMindMemoryModel Memory { get; set; }

        public string SaveFileName { get; set; }
    }
}
