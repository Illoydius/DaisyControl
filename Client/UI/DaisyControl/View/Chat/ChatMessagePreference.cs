using System.Windows.Media;

namespace DaisyControl.Client.DaisyConnect.View.Chat
{
    public class ChatMessagePreference
    {
        // ********************************************************************
        //                            Public
        // ********************************************************************
        public Color BackGroundColor { get; set; } = Color.FromArgb(255, 88, 115, 255);
        public Color BorderColor { get; set; } = Color.FromArgb(125, 48, 78, 148);
        public float BorderRadius { get; set; } = 8;
        public float BorderSize { get; set; } = 0.5f;
    }
}
