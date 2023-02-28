using System.Text.Json.Serialization;

namespace Tmf.Ocr.Core.ResponseModels;

public class DocumentMaskingResponse
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("completed_at")]
    public DateTime CompletedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = string.Empty;

    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;

    [JsonPropertyName("result")]
    public ResultMask Result { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("task_id")]
    public string TaskId { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}

public class ResultMask
{
    [JsonPropertyName("document_url")]
    public string DocumentUrl { get; set; } = string.Empty;

    [JsonPropertyName("id_number_found")]
    public bool IdNumberFound { get; set; }

    [JsonPropertyName("original_document_url")]
    public string OriginalDocumentUrl { get; set; } = string.Empty;

    [JsonPropertyName("self_link")]
    public string SelfLink { get; set; } = string.Empty;
}