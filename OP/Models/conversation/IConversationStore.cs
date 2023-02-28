namespace OpenAICommunication.Models.conversation
{
    public interface IConversationStore
    {
        public List<Conversation> Conversations { get; set; }
    }
}
