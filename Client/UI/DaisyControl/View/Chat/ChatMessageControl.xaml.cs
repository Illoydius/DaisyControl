using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DaisyControl.Client.DaisyConnect.View.Chat
{
    /// <summary>
    /// Interaction logic for ChatMessageControl.xaml
    /// </summary>
    public partial class ChatMessageControl : UserControl
    {
        public ChatMessageControl()
        {
            InitializeComponent();
        }

        public ChatMessageControl(ChatMessage aChatMessage) : this()
        {
            if(aChatMessage.IsAIMessage)
                Grid.SetColumn(MessageStackPanel, 2);

            Border.CornerRadius = new CornerRadius(aChatMessage.ChatMessagePreference.BorderRadius);
            Border.BorderThickness = new Thickness(aChatMessage.ChatMessagePreference.BorderSize);
            Border.Background = new SolidColorBrush(aChatMessage.ChatMessagePreference.BackGroundColor);
            Border.BorderBrush = new SolidColorBrush(aChatMessage.ChatMessagePreference.BorderColor);

            LabelMessage.Text = aChatMessage.Message;
            LabelTimeOfMessage.Content = DateTime.Now.ToString("hh:mm tt");
        }
    }
}
