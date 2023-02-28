namespace OpenAICommunication.Models.conversation
{
    public class Conversation : IConversation
    {
        // KEY: id, Value: (Question, Answer)
        private Dictionary<int, (string question, List<string> answers)> _questionsAndAnswers = new Dictionary<int, (string, List<string>)>();
        private int _currentId = 0;
        private string _user = "Default User";

        public Dictionary<int, (string question, List<string> answers)> QuestionsAndAnswers
        {
            get { return _questionsAndAnswers; }
        }

        public void SetUser(string user)
        {
            _user = user;
        }

        public int Count => _questionsAndAnswers.Count;

        public void Add(string question, List<string> answers)
        {
            _questionsAndAnswers.Add(_currentId++, (question, answers));
        }

        public string GetUserQuestion(int id)
        {
            return _questionsAndAnswers.TryGetValue(id, out var conversation) ? conversation.question : null;
        }

        public List<string> GetAnswersById(int id)
        {
            return _questionsAndAnswers.TryGetValue(id, out var conversation) ? conversation.answers : null;
        }
    }
}
