using FluentValidation;
using Tmf.Ocr.Core.Constants;
using Tmf.Ocr.Core.RequestModels;

namespace Tmf.Ocr.Api.Validations;

public class TaskDetailValidator : AbstractValidator<TaskDetailRequest>
{
    public TaskDetailValidator()
    {
        RuleFor(x => x.RequestId).NotEmpty().WithMessage(ValidationMessages.RequestId);
        RuleFor(x => x.RequestType).NotEmpty().WithMessage(ValidationMessages.RequestType);
    }
}
