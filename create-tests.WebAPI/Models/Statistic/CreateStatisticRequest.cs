using FluentValidation;
using FluentValidation.Results;

namespace create_tests.WebAPI.Models;

public class CreateStatisticRequest
{
    #region Model

    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public DateTime AttemptTime { get; set; }
    public int CorrectAnswers { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<CreateStatisticRequest>
    {
        public Validator()
        {
            RuleFor(x => x.CorrectAnswers)
                .GreaterThanOrEqualTo(0).WithMessage("Length must be greater or equal than 0");
        }
    }

    #endregion
}

public static class CreateStatisticRequestExtension
{
    public static ValidationResult Validate(this CreateStatisticRequest model)
    {
        return new CreateStatisticRequest.Validator().Validate(model);
    }
}