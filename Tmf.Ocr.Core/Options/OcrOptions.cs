namespace Tmf.Ocr.Core.Options;

public class OcrOptions
{
    public const string Ocr = "Ocr";
    public string ApiKey { get; set; } = string.Empty;
    public string ApiKeyValue { get; set; } = string.Empty;
    public string AccountId { get; set; } = string.Empty;
    public string AccountIdValue { get; set; } = string.Empty;
    public UrlData Url { get; set; }
}

public class UrlData
{
    public string OcrDocument { get; set; } = string.Empty;
    public string OcrAadhar { get; set; } = string.Empty;
    public string OcrDrivingLicense { get; set; } = string.Empty;
    public string OcrVoterId { get; set; } = string.Empty;
    public string OcrMasking { get; set; } = string.Empty;
    public string GetRequest { get; set; } = string.Empty;
}
