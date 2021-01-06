namespace DaisyControl.Server.DaisyMind.Modules.Memory.Objects
{
    /// <summary>
    /// All fields are 0-100
    /// </summary>
    public class SelfPersonalityModel
    {
        // ********************************************************************
        //                            Properties
        // ********************************************************************
        // Note: if you add or remove a value here, don't forget to do the same in the associate Generation model.
        public float CaringVsSelfish { get; set; }
        public float Sadist { get; set; }
    }
}
