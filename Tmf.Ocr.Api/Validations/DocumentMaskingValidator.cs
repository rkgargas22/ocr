using FluentValidation;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.RequestModels;

namespace Tmf.Ocr.Api.Validations;

public class DocumentMaskingValidator : AbstractValidator<DocumentMaskingRequest>
{
    public DocumentMaskingValidator()
    {
        RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidationMessages.TaskId);
        RuleFor(x => x.GroupId).NotEmpty().WithMessage(ValidationMessages.GroupId);
        RuleFor(x => x.Data).NotEmpty().WithMessage(ValidationMessages.Data);
        RuleFor(x => x.Data).SetValidator(new DataMaskingValidator()).When(x => x.Data != null);
    }
}

public class DataMaskingValidator : AbstractValidator<DataMasking>
{
    public DataMaskingValidator()
    {
        RuleFor(x => x.Document1).NotEmpty().WithMessage(ValidationMessages.Document1);
        RuleFor(x => x.Consent).NotEmpty().WithMessage(ValidationMessages.Consent);
    }
}