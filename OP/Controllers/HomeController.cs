using Microsoft.AspNetCore.Mvc;
using OpenAICommunication.API;
using OpenAICommunication.Models.conversation;
using OpenAICommunication.Models.request;
using System.Text;

namespace OpenAICommunication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConversationStore _conversationStore;
        private readonly IConversation _currentConversation;
        private readonly IOpenAICalls _openAICalls;

        public HomeController(IOpenAICalls openAICalls, IConversationStore conversationStore)
        {
            _openAICalls = openAICalls;
            _conversationStore = conversationStore;
            _currentConversation = conversationStore.Conversations[0];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompletion(string input, int nInput, double tempInput)
        {
            try
            {
                var prompt = BuildPrompt(input, nInput);
                var response = await _openAICalls.CreateCompletionAsync(new CompletionRequest()
                {
                    Model = "text-davinci-003",
                    Prompt = prompt,
                    MaxTokens = 200,
                    Temperature = tempInput,
                    TopP = 1,
                    NumChoicesPerPrompt = nInput,
                    Stream = false,
                    Stop = "",
                    User = "max",
                    PresencePenalty = 0,
                    FrequencyPenalty = 0,
                });

                var answers = response.Completions.Select(choice => choice.Text).ToList();
                _currentConversation.Add(input, answers);

                var result = BuildResult();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        private string BuildPrompt(string input, int nInput)
        {
            var sb = new StringBuilder();
            if (_currentConversation.Count > 0)
            {
                sb.AppendLine("");
                for (int i = 0; i < _currentConversation.Count; i++)
                {
                    sb.AppendLine($"Q: {_currentConversation.GetUserQuestion(i)}");
                    sb.AppendLine("A: " + string.Join("", _currentConversation.GetAnswersById(i)));
                }
            }

            sb.AppendLine($"Q: {input}");
            sb.AppendLine("A:");
            return sb.ToString();
        }

        private string BuildResult()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _currentConversation.Count; i++)
            {
                sb.AppendLine($"From User:\n{_currentConversation.GetUserQuestion(i)}");
                sb.AppendLine();
                sb.AppendLine("From Chatbot: " + string.Join("", _currentConversation.GetAnswersById(i)));
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}