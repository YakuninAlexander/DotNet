using create_test.Entities.Models;

namespace create_test.Services.Models;

public class UpdateQuestionModel
{
    public string Question { get; set; }
    public string RightAnswers { get; set; }
    public string Answers { get; set; }
}