using FluentValidation;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.RequestModels;

namespace Tmf.Ocr.Api.Validations;

public class ValidationDocumentValidator : AbstractValidator<ValidateDocumentRequest>
{
    public ValidationDocumentValidator()
    {
        RuleFor(x => x.GroupId).NotEmpty().WithMessage(ValidationMessages.GroupId);
        RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidationMessages.TaskId);
        RuleFor(x => x.Data).NotEmpty().WithMessage(ValidationMessages.Data);
        RuleFor(x => x.Data).SetValidator(new DataValidator()).When(x => x.Data != null);
    }
}

public class DataValidator : AbstractValidator<Data>
{
    public DataValidator() 
    {
        RuleFor(x => x.Document1).NotEmpty().WithMessage(ValidationMessages.Document1);
        RuleFor(x => x.DocType).NotEmpty().WithMessage(ValidationMessages.DocType);
        RuleFor(x => x.AdvancedFeatures).NotEmpty().WithMessage(ValidationMessages.AdvancedFeatures);
        RuleFor(x => x.AdvancedFeatures).SetValidator(new AdvanceFeatureValidator()).When(x => x.AdvancedFeatures != null);
    }
}

public class AdvanceFeatureValidator : AbstractValidator<AdvancedFeatures>
{
    public AdvanceFeatureValidator()
    {
        RuleFor(x => x.DetectDocSide).NotEmpty().WithMessage(ValidationMessages.DetectDocSide);
    }
}
