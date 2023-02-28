using System.Text.Json.Serialization;

namespace Tmf.Ocr.Core.RequestModels; 

public class DrivingLicenseExtractRequest 
{
    [JsonPropertyName("task_id")]
    public string TaskId { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public DataDL Data { get; set; }
}

public class DataDL
{
    [JsonPropertyName("document1")]
    public string Document1 { get; set; } = string.Empty;

    [JsonPropertyName("document2")]
    public string Document2 { get; set; } = string.Empty;
}