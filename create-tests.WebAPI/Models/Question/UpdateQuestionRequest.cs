using FluentValidation;
using FluentValidation.Results;

namespace create_tests.WebAPI.Models;

public class UpdateQuestionRequest
{
    #region Model

    public string Question { get; set; }
    public string RightAnswers { get; set; }
    public string Answers { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateQuestionRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Question)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateQuestionRequestExtension
{
    public static ValidationResult Validate(this UpdateQuestionRequest model)
    {
        return new UpdateQuestionRequest.Validator().Validate(model);
    }
}