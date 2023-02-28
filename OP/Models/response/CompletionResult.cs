using OpenAICommunication.Models.shared;
using System.Text.Json.Serialization;

namespace OpenAICommunication.Models.response
{
    public class CompletionResult : BaseResponse
    {
        [JsonConstructor]
        public CompletionResult(
            string id,
            string @object,
            int createdUnixTime,
            string model,
            List<Choice> completions)
        {
            Id = id;
            Object = @object;
            CreatedUnixTime = createdUnixTime;
            Model = model;
            Completions = completions;
        }

        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("object")]
        public string Object { get; }

        [JsonPropertyName("created")]
        public int CreatedUnixTime { get; }

        [JsonIgnore]
        public DateTime Created => DateTimeOffset.FromUnixTimeSeconds(CreatedUnixTime).DateTime;

        [JsonPropertyName("model")]
        public string Model { get; }

        [JsonPropertyName("choices")]
        public List<Choice> Completions { get; }

        public override string ToString()
        {
            return Completions is { Count: > 0 }
                ? Completions[0]
                : $"CompletionResult {Id} has no valid output";
        }
    }
}
