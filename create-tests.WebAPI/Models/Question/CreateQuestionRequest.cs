using FluentValidation;
using FluentValidation.Results;

namespace create_tests.WebAPI.Models;

public class CreateQuestionRequest
{
    #region Model

    public string Question { get; set; }
    public string RightAnswers { get; set; }
    public string Answers { get; set; }
    public Guid TestID { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<CreateQuestionRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Question)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class CreateQuestionRequestExtension
{
    public static ValidationResult Validate(this CreateQuestionRequest model)
    {
        return new CreateQuestionRequest.Validator().Validate(model);
    }
}