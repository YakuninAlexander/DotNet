using FluentValidation;
using FluentValidation.Results;

namespace create_tests.WebAPI.Models;

public class UpdateStatisticRequest
{
    #region Model

    public int CorrectAnswers { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateStatisticRequest>
    {
        public Validator()
        {
            RuleFor(x => x.CorrectAnswers)
                .GreaterThanOrEqualTo(0).WithMessage("Length must be greater or equal than 0");
        }
    }

    #endregion
}

public static class UpdateStatisticRequestExtension
{
    public static ValidationResult Validate(this UpdateStatisticRequest model)
    {
        return new UpdateStatisticRequest.Validator().Validate(model);
    }
}