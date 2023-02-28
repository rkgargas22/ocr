using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.Exception;
using Tmf.Ocr.Core.RequestModels;
using Tmf.Ocr.Core.ResponseModels;
using Tmf.Ocr.Manager.Interfaces;

namespace Tmf.Ocr.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OcrController : ControllerBase
{
    private readonly IOcrManager _ocrManager;
    private readonly IValidator<AadharExtractRequest> _aadharExtractValidator;
    private readonly IValidator<DrivingLicenseExtractRequest> _drivingLicenseExtractValidator;
    private readonly IValidator<VoterIdExtractionRequest> _voterIdExtractionValidator;
    private readonly IValidator<ValidateDocumentRequest> _validateDocumentValidator;
    private readonly IValidator<DocumentMaskingRequest> _documentMaskingValidator;
    private readonly IValidator<TaskDetailRequest> _taskDetailValidator;

    public OcrController(IOcrManager ocrManager, IValidator<AadharExtractRequest> aadharExtractValidator, IValidator<DrivingLicenseExtractRequest> drivingLicenseExtractValidator, IValidator<VoterIdExtractionRequest> voterIdExtractionValidator, IValidator<ValidateDocumentRequest> validateDocumentValidator, IValidator<TaskDetailRequest> taskDetailValidator, IValidator<DocumentMaskingRequest> documentMaskingValidator)
    {
        _ocrManager = ocrManager;
        _aadharExtractValidator = aadharExtractValidator;
        _drivingLicenseExtractValidator = drivingLicenseExtractValidator;
        _voterIdExtractionValidator = voterIdExtractionValidator;
        _validateDocumentValidator = validateDocumentValidator;
        _taskDetailValidator = taskDetailValidator;
        _documentMaskingValidator = documentMaskingValidator;
    }

    [HttpPost]
    [Route("AadharExtract")]
    [ProducesDefaultResponseType(typeof(TaskDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(TaskDetailResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> AadharExtract([FromBody] AadharExtractRequest aadharExtractRequest)
    {
        ValidationResult result = await _aadharExtractValidator.ValidateAsync(aadharExtractRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _ocrManager.AadharExtract(aadharExtractRequest);

        if (data != null && string.IsNullOrEmpty(data.RequestId))
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.ErrorInRequest, Error = data });
        }
        return CreatedAtAction(nameof(AadharExtract), new { data.RequestId }, data);
    }

    [HttpPost]
    [Route("DrivingLicenseExtract")]
    [ProducesDefaultResponseType(typeof(TaskDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(TaskDetailResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> DrivingLicenseExtract([FromBody] DrivingLicenseExtractRequest drivingLicenseExtractRequest)
    {
        ValidationResult result = await _drivingLicenseExtractValidator.ValidateAsync(drivingLicenseExtractRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _ocrManager.DrivingLicenseExtract(drivingLicenseExtractRequest);

        if (data != null && string.IsNullOrEmpty(data.RequestId))
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.ErrorInRequest, Error = data });
        }
        return CreatedAtAction(nameof(DrivingLicenseExtract), new { data.RequestId }, data);
    }

    [HttpPost]
    [Route("VoterIdExtract")]
    [ProducesDefaultResponseType(typeof(TaskDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(TaskDetailResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> VoterIdExtract([FromBody] VoterIdExtractionRequest voterIdExtractionRequest)
    {
        ValidationResult result = await _voterIdExtractionValidator.ValidateAsync(voterIdExtractionRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _ocrManager.VoterIdExtract(voterIdExtractionRequest);

        if (data != null && string.IsNullOrEmpty(data.RequestId))
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.ErrorInRequest, Error = data });
        }
        return CreatedAtAction(nameof(VoterIdExtract), new { data.RequestId }, data);
    }

    [HttpPost]
    [Route("ValidateDocument")]
    [ProducesDefaultResponseType(typeof(TaskDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(TaskDetailResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> ValidateDocument([FromBody] ValidateDocumentRequest validateDocumentRequest)
    {
        ValidationResult result = await _validateDocumentValidator.ValidateAsync(validateDocumentRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _ocrManager.ValidateDocument(validateDocumentRequest);

        if (data != null && string.IsNullOrEmpty(data.RequestId))
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.ErrorInRequest, Error = data });
        }
        return CreatedAtAction(nameof(ValidateDocument), new { data.RequestId }, data);
    }

    [HttpPost]
    [Route("MaskDocument")]
    [ProducesDefaultResponseType(typeof(TaskDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(TaskDetailResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> MaskDocument([FromBody] DocumentMaskingRequest documentMaskingRequest)
    {
        ValidationResult result = await _documentMaskingValidator.ValidateAsync(documentMaskingRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _ocrManager.MaskDocument(documentMaskingRequest);

        if (data != null && string.IsNullOrEmpty(data.RequestId))
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.ErrorInRequest, Error = data });
        }
        return CreatedAtAction(nameof(MaskDocument), new { data.RequestId }, data);
    }

    [HttpGet]
    [Route("GetTaskDetails")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(List<AadharExtractResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<DrivingLicenseExtractResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<VoterIdExtractResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<ValidateDocumentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<DocumentMaskingResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTaskDetails([FromQuery] TaskDetailRequest taskDetailRequest)
    {
        ValidationResult result = await _taskDetailValidator.ValidateAsync(taskDetailRequest);

        if (!result.IsValid)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
        }
        var data = await _ocrManager.TaskDetail(taskDetailRequest);
        if(data == null)
        {
            return BadRequest(new ErrorResponse { Message = ValidationMessages.ErrorInRequest, Error = data });
        }
        return Ok(data);
    }
}
