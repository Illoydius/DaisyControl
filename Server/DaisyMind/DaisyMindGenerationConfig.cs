namespace DaisyControl.Server.DaisyMind
{
    /// <summary>
    /// Config file to customize the desired DaisyMind.
    /// </summary>
    public class DaisyMindGenerationConfig
    {
        // ********************************************************************
        //                            Nested
        // ********************************************************************
        public class DaisyMindGenerationPersonality
        {
            // ********************************************************************
            //                            Properties
            // ********************************************************************
            // Note: if you add or remove a value here, don't forget to do the same in the associate personality model.
            public float CaringVsSelfish { get; set; }
            public float Sadist { get; set; }
        }

        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public DaisyMindGenerationPersonality Personality { get; set; }
    }
}
