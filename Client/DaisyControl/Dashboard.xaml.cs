using System.Text;
using System.Windows;
using System.Windows.Media;
using DaisyControl.Client.DaisyConnect.Constants;
using DaisyControl.Client.DaisyConnect.Utils;
using DaisyControl.Client.DaisyConnect.View.Chat;

namespace DaisyControl.Client.DaisyConnect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ********************************************************************
        //                            Constructors
        // ********************************************************************
        public MainWindow()
        {
            InitializeComponent();

            // Load custom components
            LoadComponents();
        }

        // ********************************************************************
        //                            Private
        // ********************************************************************
        private void LoadComponents()
        {
            // Load image and set it to the domme image control
            DommeImage.Source = ImageUtils.GetBitmapImageFromImageOnDisk(@$"{DommeConstants.SOURCE_DOMME_IMAGES_PATH}\Dev\DommeTest.jpeg"); // TODO: fetch real image from save file

            // Load domme status

            ImageMoodIndicator.Source = ImageUtils.GetBitmapImageFromImageOnDisk($@"{DommeConstants.SOURCE_ICONS_IMAGES_PATH}\Indicators\Green.png");
            MoodIndicatorLabel.Content = "Annoyed";

            ImageInteractionIndicator.Source = ImageUtils.GetBitmapImageFromImageOnDisk($@"{DommeConstants.SOURCE_ICONS_IMAGES_PATH}\Indicators\Red.png");
            InteractionIndicatorLabel.Content = "Wants to talk to you";

            // Dummy chat
            ChatMessagePreference _AiChatMessagePreference = new()
            {
                BackGroundColor = Color.FromArgb(255, 47, 158, 114),
            };

            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "Test from your AI.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "2.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "3.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "4.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "5.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "6.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "7.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "8.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "9.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "10.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "11.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "12.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "13.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "14.", true), 500);
            Chat.AddMessage(new ChatMessage(_AiChatMessagePreference, "15.", true), 500);

            Chat.AddMessage(new ChatMessage(new ChatMessagePreference(), "Test from you."));
        }
    }
}
