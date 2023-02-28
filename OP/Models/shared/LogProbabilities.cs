using System.Text.Json.Serialization;

namespace OpenAICommunication.Models.shared
{
    public class LogProbabilities
    {
        [JsonConstructor]
        public LogProbabilities(
            IReadOnlyList<string> tokens,
            IReadOnlyList<double> tokenLogProbabilities,
            IList<IDictionary<string, double>> topLogProbabilities,
            IReadOnlyList<int> textOffsets)
        {
            Tokens = tokens;
            TokenLogProbabilities = tokenLogProbabilities;
            TopLogProbabilities = topLogProbabilities;
            TextOffsets = textOffsets;
        }

        [JsonPropertyName("tokens")]
        public IReadOnlyList<string> Tokens { get; }

        [JsonPropertyName("token_logprobs")]
        public IReadOnlyList<double> TokenLogProbabilities { get; }

        [JsonPropertyName("top_logprobs")]
        public IList<IDictionary<string, double>> TopLogProbabilities { get; }

        [JsonPropertyName("text_offset")]
        public IReadOnlyList<int> TextOffsets { get; }
    }
}
