using FluentValidation;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.RequestModels;

namespace Tmf.Ocr.Api.Validations;

public class AadharExtractValidator : AbstractValidator<AadharExtractRequest>
{
    public AadharExtractValidator()
    {
        RuleFor(x => x.GroupId).NotEmpty().WithMessage(ValidationMessages.GroupId);
        RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidationMessages.TaskId);
        RuleFor(x => x.Data).NotEmpty().WithMessage(ValidationMessages.Data);
        RuleFor(x => x.Data).SetValidator(new DataAadharValidator()).When(x => x.Data != null);
    }
}

public class DataAadharValidator : AbstractValidator<DataAadhar>
{
    public DataAadharValidator()
    {
        RuleFor(x => x.Consent).NotEmpty().WithMessage(ValidationMessages.Consent);
        RuleFor(x => x.Document1).NotEmpty().WithMessage(ValidationMessages.Document1);
        RuleFor(x => x.Document2).NotEmpty().WithMessage(ValidationMessages.Document2);
    }
}
