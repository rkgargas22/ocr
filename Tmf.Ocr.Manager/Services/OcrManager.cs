using Tmf.Ocr.Core.RequestModels;
using Tmf.Ocr.Core.ResponseModels;
using Tmf.Ocr.Infrastructure.Interfaces;
using Tmf.Ocr.Manager.Interfaces;

namespace Tmf.Ocr.Manager.Services;

public class OcrManager : IOcrManager
{
    private readonly IOcrRepository _ocrRepository;

    public OcrManager(IOcrRepository ocrRepository)
    {
        _ocrRepository = ocrRepository;
    }

    public async Task<TaskDetailResponse> AadharExtract(AadharExtractRequest aadharExtractRequest)
    {
        return await _ocrRepository.AadharExtract(aadharExtractRequest);
    }

    public async Task<TaskDetailResponse> DrivingLicenseExtract(DrivingLicenseExtractRequest drivingLicenseExtractRequest)
    {
        return await _ocrRepository.DrivingLicenseExtract(drivingLicenseExtractRequest);
    }

    public async Task<TaskDetailResponse> MaskDocument(DocumentMaskingRequest documentMaskingRequest)
    {
        return await _ocrRepository.MaskDocument(documentMaskingRequest);
    }

    public async Task<dynamic> TaskDetail(TaskDetailRequest taskDetailRequest)
    {
        return await _ocrRepository.TaskDetail(taskDetailRequest);
    }

    public async Task<TaskDetailResponse> ValidateDocument(ValidateDocumentRequest validateDocumentRequest)
    {
        return await _ocrRepository.ValidateDocument(validateDocumentRequest);
    }

    public async Task<TaskDetailResponse> VoterIdExtract(VoterIdExtractionRequest voterIdExtractionRequest)
    {
        return await _ocrRepository.VoterIdExtract(voterIdExtractionRequest);
    }
}
