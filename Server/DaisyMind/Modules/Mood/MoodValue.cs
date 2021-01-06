namespace DaisyControl.Server.DaisyMind.Modules.Mood
{
    public class MoodValue
    {
        // ********************************************************************
        //                            ctor
        // ********************************************************************
        public MoodValue()
        {
            // For serialization purpose
        }

        public MoodValue(float aMinValue, float aMaxValue)
        {
            fMinValue = aMinValue;
            fMaxValue = aMaxValue;
        }

        // ********************************************************************
        //                            Internal
        // ********************************************************************
        public readonly float fMaxValue = 100;
        public readonly float fMinValue = 0;

        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public float Value { get; set; } = 50;
    }
}
