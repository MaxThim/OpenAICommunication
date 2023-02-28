using OpenAICommunication.Models.request;
using OpenAICommunication.Models.response;

namespace OpenAICommunication.API
{
    public interface IOpenAICalls
    {
        Task<CompletionResult> CreateCompletionAsync(CompletionRequest completionRequest);
    }
}