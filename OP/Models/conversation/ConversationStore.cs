namespace OpenAICommunication.Models.conversation
{
    public class ConversationStore : IConversationStore
    {
        public List<Conversation> Conversations { get; set; } = new() 
        {
            new() 
        };
    }
}
