using System.Text.Json.Serialization;

namespace OpenAICommunication.Models
{
    public abstract class BaseResponse
    {
        [JsonIgnore]
        public TimeSpan ProcessingTime { get; internal set; }

        [JsonIgnore]
        public string Organization { get; internal set; }

        [JsonIgnore]
        public string RequestId { get; internal set; }
    }
}
