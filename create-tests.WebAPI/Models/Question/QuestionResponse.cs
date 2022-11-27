namespace create_tests.WebAPI.Models;

public class QuestionResponse
{
    public Guid Id { get; set; }
    public string Question { get; set; }
    public string RightAnswers { get; set; }
    public string Answers { get; set; }
}