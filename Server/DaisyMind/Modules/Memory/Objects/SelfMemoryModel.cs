using DaisyControl.Server.DaisyMind.Modules.Mood;

namespace DaisyControl.Server.DaisyMind.Modules.Memory.Objects
{
    /// <summary>
    /// Represents the memory Daisy Mind have about herself.
    /// </summary>
    public class SelfMemoryModel
    {
        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public DaisyMindMoodModel Mood { get; set; }
        public SelfPersonalityModel Personality { get; set; }
    }
}
