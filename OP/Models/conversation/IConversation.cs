namespace OpenAICommunication.Models.conversation
{
    public interface IConversation
    {
        int Count { get; }
        Dictionary<int, (string question, List<string> answers)> QuestionsAndAnswers { get; }

        void Add(string question, List<string> answers);
        List<string> GetAnswersById(int id);
        string GetUserQuestion(int id);
        void SetUser(string user);
    }
}