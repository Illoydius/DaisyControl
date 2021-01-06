namespace DaisyControl.Server.DaisyMind.Modules.Mood
{
    /// <summary>
    /// The mood represents how the DaisyMind feels
    /// </summary>
    public class DaisyMindMoodModel
    {
        // ********************************************************************
        //                            Properties
        // ********************************************************************
        // If Daisy Mind is joyous, she will be more inclined to have positive interactions with the user, things that the user will like, reward, etc
        // On the contrary, if she's not joyous, she's angered and will seek confrontation, making the user do things he doesn't like.
        public MoodValue Joy { get; set; } = new();

        // If Daisy Mind is in a teasing mood, she may be more inclined to tease the user more (way more possibly) than usual
        public MoodValue Tease { get; set; } = new();
    }
}
