using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DaisyControl.Client.DaisyConnect.View.Chat
{
    /// <summary>
    /// Interaction logic for ChatControl.xaml
    /// </summary>
    public partial class ChatControl : UserControl
    {
        // ********************************************************************
        //                            Constructors
        // ********************************************************************
        public ChatControl()
        {
            InitializeComponent();
        }

        // ********************************************************************
        //                            Private
        // ********************************************************************
        private volatile List<ChatMessage> fMessages = new();

        // ********************************************************************
        //                            Public
        // ********************************************************************
        /// <summary>
        /// Add message with potential delay to represent the time required to type the message.
        /// </summary>
        /// <param name="aChatMessage"></param>
        /// <param name="aMSDelay">milliseconds to delay to represent typing.</param>
        public void AddMessage(ChatMessage aChatMessage, int aMSDelay = 0)
        {
            Action _Action = () =>
            {
                if (aMSDelay > 0)
                    Task.Delay(aMSDelay);

                this.Dispatcher.Invoke(() =>
                {
                    MessagesListView.Items.Add(new ChatMessageControl(aChatMessage));
                    ChatScrollViewer.ScrollToBottom();
                });

                fMessages.Add(aChatMessage);
            };

            if (aMSDelay > 0)
                Task.Run(_Action);
            else
                _Action.Invoke();
        }
    }
}
