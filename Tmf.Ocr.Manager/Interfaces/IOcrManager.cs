using Tmf.Ocr.Core.RequestModels;
using Tmf.Ocr.Core.ResponseModels;

namespace Tmf.Ocr.Manager.Interfaces;

public interface IOcrManager
{
    Task<TaskDetailResponse> ValidateDocument(ValidateDocumentRequest validateDocumentRequest);

    Task<TaskDetailResponse> AadharExtract(AadharExtractRequest aadharExtractRequest);

    Task<TaskDetailResponse> DrivingLicenseExtract(DrivingLicenseExtractRequest drivingLicenseExtractRequest);

    Task<TaskDetailResponse> VoterIdExtract(VoterIdExtractionRequest voterIdExtractionRequest);

    Task<TaskDetailResponse> MaskDocument(DocumentMaskingRequest documentMaskingRequest);

    Task<dynamic> TaskDetail(TaskDetailRequest taskDetailRequest);
}
