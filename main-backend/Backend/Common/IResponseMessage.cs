using Newtonsoft.Json;

namespace Backend.Common
{
    public interface IResponseMessage
    {
        [JsonProperty(nameof(ErrorLevel))]
        string ErrorLevel { get; set; }

        [JsonProperty(nameof(Message))]
        string Message { get; set; }

        [JsonProperty(nameof(StatusCode))]
        int StatusCode { get; set; }
    }
}
