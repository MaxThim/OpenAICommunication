using System.Text.Json.Serialization;

namespace OpenAICommunication.Models.shared
{
    public class Choice
    {
        [JsonConstructor]
        public Choice(
            string text,
            int index,
            LogProbabilities logProbabilities,
            string finishReason)
        {
            Text = text;
            Index = index;
            LogProbabilities = logProbabilities;
            FinishReason = finishReason;
        }

        [JsonPropertyName("text")]
        public string Text { get; }

        [JsonPropertyName("index")]
        public int Index { get; }

        [JsonPropertyName("logprobs")]
        public LogProbabilities LogProbabilities { get; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; }

        public override string ToString() => Text;

        public static implicit operator string(Choice choice) => choice.Text;
    }
}
