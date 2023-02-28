using FluentValidation;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.RequestModels;

namespace Tmf.Ocr.Api.Validations;

public class DrivingLicenseExtractValidator : AbstractValidator<DrivingLicenseExtractRequest>
{
    public DrivingLicenseExtractValidator()
    {
        RuleFor(x => x.GroupId).NotEmpty().WithMessage(ValidationMessages.GroupId);
        RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidationMessages.TaskId);
        RuleFor(x => x.Data).NotEmpty().WithMessage(ValidationMessages.Data);
        RuleFor(x => x.Data).SetValidator(new DataDLValidator()).When(x => x.Data != null);
    }
}

public class DataDLValidator : AbstractValidator<DataDL>
{
    public DataDLValidator()
    {
        RuleFor(x => x.Document1).NotEmpty().WithMessage(ValidationMessages.Document1);
        RuleFor(x => x.Document2).NotEmpty().WithMessage(ValidationMessages.Document2);
    }
}
