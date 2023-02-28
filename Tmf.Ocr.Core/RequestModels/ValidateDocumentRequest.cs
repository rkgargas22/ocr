using System.Text.Json.Serialization;

namespace Tmf.Ocr.Core.RequestModels;

public class ValidateDocumentRequest
{
    [JsonPropertyName("task_id")]
    public string TaskId { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class AdvancedFeatures
{
    [JsonPropertyName("detect_doc_side")]
    public bool DetectDocSide { get; set; }
}

public class Data
{
    [JsonPropertyName("document1")]
    public string Document1 { get; set; } = string.Empty;

    [JsonPropertyName("doc_type")]
    public string DocType { get; set; } = string.Empty;

    [JsonPropertyName("advanced_features")]
    public AdvancedFeatures AdvancedFeatures { get; set; }
}