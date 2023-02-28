using System.Text.Json.Serialization;

namespace Tmf.Ocr.Core.RequestModels;

public class TaskDetailRequest
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;
    [JsonPropertyName("request_type")]
    public string RequestType { get; set; } = string.Empty;
}
