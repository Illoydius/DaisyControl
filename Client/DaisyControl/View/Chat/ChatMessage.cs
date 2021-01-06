namespace DaisyControl.Client.DaisyConnect.View.Chat
{
    public class ChatMessage
    {
        // ********************************************************************
        //                            Constructors
        // ********************************************************************
        public ChatMessage() { }

        public ChatMessage(ChatMessagePreference aChatMessagePreference, string aMessage, bool aIsAiMessage = false)
        {
            this.ChatMessagePreference = aChatMessagePreference;
            this.Message = aMessage;
            this.IsAIMessage = aIsAiMessage;
        }

        // ********************************************************************
        //                            Properties
        // ********************************************************************
        public ChatMessagePreference ChatMessagePreference { get; set; } = new();
        public bool IsAIMessage { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
