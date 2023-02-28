using System.Reflection;
using System.Text.Json.Serialization;

namespace OpenAICommunication.Models.request
{
    public class CompletionRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; init; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; init; } = "";

        [JsonPropertyName("suffix")]
        public string? Suffix { get; init; }

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; init; }

        [JsonPropertyName("temperature")]
        public double? Temperature { get; init; }

        [JsonPropertyName("top_p")]
        public double? TopP { get; init; }

        [JsonPropertyName("presence_penalty")]
        public double? PresencePenalty { get; init; }

        [JsonPropertyName("frequency_penalty")]
        public double? FrequencyPenalty { get; init; }

        [JsonPropertyName("n")]
        public int? NumChoicesPerPrompt { get; init; }

        [JsonPropertyName("stream")]
        public bool Stream { get; internal set; }

        [JsonPropertyName("logprobs")]
        public int? LogProbabilities { get; init; }

        [JsonPropertyName("echo")]
        public bool? Echo { get; init; }

        [JsonPropertyName("stop")]
        public string Stop { get; internal set; }

        //[JsonIgnore]
        //public string StopSequence
        //{
        //    get => StopSequences?.FirstOrDefault();
        //    set
        //    {
        //        if (value == null)
        //        {
        //            StopSequences = Array.Empty<string>();
        //        }
        //        else
        //        {
        //            if (StopSequences.Length == 1)
        //            {
        //                StopSequences[0] = value;
        //            }
        //            else
        //            {
        //                StopSequences = new[] { value };
        //            }
        //        }
        //    }
        //}

        [JsonPropertyName("logit_bias")]
        public Dictionary<string, double> LogitBias { get; init; }

        [JsonPropertyName("best_of")]
        public int? BestOf { get; init; }

        [JsonPropertyName("user")]
        public string User { get; init; }

        [JsonIgnore]
        public static CompletionRequest DefaultCompletionRequestArgs { get; set; } = null;


    }
}
