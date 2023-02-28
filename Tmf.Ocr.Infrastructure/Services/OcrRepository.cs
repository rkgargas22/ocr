using Microsoft.Extensions.Options;
using System.Text.Json;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.Options;
using Tmf.Ocr.Core.RequestModels;
using Tmf.Ocr.Core.ResponseModels;
using Tmf.Ocr.Infrastructure.HttpServices;
using Tmf.Ocr.Infrastructure.Interfaces;

namespace Tmf.Ocr.Infrastructure.Services;

public class OcrRepository : IOcrRepository
{
    private readonly IHttpServices _httpServices;
    private readonly OcrOptions _options;

    public OcrRepository(IHttpServices httpServices, IOptions<OcrOptions> options)
    {
        _httpServices = httpServices;
        _options = options.Value;
    }

    public async Task<TaskDetailResponse> AadharExtract(AadharExtractRequest aadharExtractRequest)
    {
        var result = await _httpServices.PostAsync(_options.Url.OcrAadhar, aadharExtractRequest);

        if (result == null)
        {
            return new TaskDetailResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<TaskDetailResponse>(result, jsonSerializerOptions);
    }

    public async Task<TaskDetailResponse> DrivingLicenseExtract(DrivingLicenseExtractRequest drivingLicenseExtractRequest)
    {
        var result = await _httpServices.PostAsync(_options.Url.OcrDrivingLicense, drivingLicenseExtractRequest);

        if (result == null)
        {
            return new TaskDetailResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<TaskDetailResponse>(result, jsonSerializerOptions);
    }

    public async Task<TaskDetailResponse> MaskDocument(DocumentMaskingRequest documentMaskingRequest)
    {
        var result = await _httpServices.PostAsync(_options.Url.OcrMasking, documentMaskingRequest);

        if (result == null)
        {
            return new TaskDetailResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<TaskDetailResponse>(result, jsonSerializerOptions);
    }

    public async Task<dynamic> TaskDetail(TaskDetailRequest taskDetailRequest)
    {
        var result = await _httpServices.GetAsync(_options.Url.GetRequest + taskDetailRequest.RequestId);

        dynamic data = null;

        if (result == null)
        {
            return data;
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        if(taskDetailRequest.RequestType == RequestType.VALIDATION)
        {
            data = JsonSerializer.Deserialize<List<ValidateDocumentResponse>>(result, jsonSerializerOptions);
        }
        else if (taskDetailRequest.RequestType == RequestType.AADHAR)
        {
            data = JsonSerializer.Deserialize<List<AadharExtractResponse>>(result, jsonSerializerOptions);
        }
        else if (taskDetailRequest.RequestType == RequestType.DL)
        {
            data = JsonSerializer.Deserialize<List<DrivingLicenseExtractResponse>>(result, jsonSerializerOptions);
        }
        else if (taskDetailRequest.RequestType == RequestType.VOTERID)
        {
            data = JsonSerializer.Deserialize<List<VoterIdExtractResponse>>(result, jsonSerializerOptions);
        }
        else if (taskDetailRequest.RequestType == RequestType.MASKING)
        {
            data = JsonSerializer.Deserialize<List<DocumentMaskingResponse>>(result, jsonSerializerOptions);
        }

        return data;
    }

    public async Task<TaskDetailResponse> ValidateDocument(ValidateDocumentRequest validateDocumentRequest)
    {
        var result = await _httpServices.PostAsync(_options.Url.OcrDocument, validateDocumentRequest);

        if (result == null)
        {
            return new TaskDetailResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<TaskDetailResponse>(result, jsonSerializerOptions);
    }

    public async Task<TaskDetailResponse> VoterIdExtract(VoterIdExtractionRequest voterIdExtractionRequest)
    {
        var result = await _httpServices.PostAsync(_options.Url.OcrVoterId, voterIdExtractionRequest);

        if (result == null)
        {
            return new TaskDetailResponse();
        }

        var jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };

        return JsonSerializer.Deserialize<TaskDetailResponse>(result, jsonSerializerOptions);
    }
}
