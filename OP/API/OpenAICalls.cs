using OpenAICommunication.extensions;
using OpenAICommunication.Models.request;
using OpenAICommunication.Models.response;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OpenAICommunication.API
{
    public class OpenAICalls : IOpenAICalls
    {
        private HttpClient _client { get; }
        private string ApiKey = "";
        private string _orginizationID = null;

        public OpenAICalls()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

            if (!string.IsNullOrWhiteSpace(_orginizationID))
            {
                _client.DefaultRequestHeaders.Add("OpenAI-Organization", _orginizationID);
            }
        }

        public async Task<CompletionResult> CreateCompletionAsync(CompletionRequest completionRequest)
        {
            completionRequest.Stream = false;
            var jsOptions = new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
            var jsonContent = JsonSerializer.Serialize(completionRequest, jsOptions);
            var response = await _client.PostAsync("https://api.openai.com/v1/completions", jsonContent.ToJsonStringContent()).ConfigureAwait(false);
            var responseAsString = await response.ReadAsStringAsync().ConfigureAwait(false);

            var result = JsonSerializer.Deserialize<CompletionResult>(responseAsString, jsOptions);
            if (result?.Completions == null || result.Completions.Count == 0)
            {
                throw new HttpRequestException($"No completions! HTTP status code: {response.StatusCode}. Response body: {responseAsString}");
            }
            result.SetResponseData(response.Headers);
            return result;
        }
    }
}
