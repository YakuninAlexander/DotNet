using FluentValidation;
using FluentValidation.Results;

namespace create_tests.WebAPI.Models;

public class CreateTestRequest
{
    #region Model

    public Guid UserID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPrivate { get; set; }
    public DateTime CreateDate { get; set; }
    public int Popularity { get; set; }
    public int QuestionCount { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<CreateTestRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class CreateTestRequestExtension
{
    public static ValidationResult Validate(this CreateTestRequest model)
    {
        return new CreateTestRequest.Validator().Validate(model);
    }
}