using FluentValidation;
using FluentValidation.Results;

namespace create_tests.WebAPI.Models;

public class UpdateTestRequest
{
    #region Model

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPrivate { get; set; }
    public DateTime CreateDate { get; set; }
    public int Popularity { get; set; }
    public int QuestionCount { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateTestRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateTestRequestExtension
{
    public static ValidationResult Validate(this UpdateTestRequest model)
    {
        return new UpdateTestRequest.Validator().Validate(model);
    }
}