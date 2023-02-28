using FluentValidation;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.RequestModels;

namespace Tmf.Ocr.Api.Validations;

public class VoterIdExtractValidator : AbstractValidator<VoterIdExtractionRequest>
{
    public VoterIdExtractValidator()
    {
        RuleFor(x => x.GroupId).NotEmpty().WithMessage(ValidationMessages.GroupId);
        RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidationMessages.TaskId);
        RuleFor(x => x.Data).NotEmpty().WithMessage(ValidationMessages.Data);
        RuleFor(x => x.Data).SetValidator(new DataVoterIdValidator()).When(x => x.Data != null);
    }
}

public class DataVoterIdValidator : AbstractValidator<DataVoterId>
{
    public DataVoterIdValidator()
    {
        RuleFor(x => x.Document1).NotEmpty().WithMessage(ValidationMessages.Document1);
        RuleFor(x => x.Document2).NotEmpty().WithMessage(ValidationMessages.Document2);
    }
}
