namespace create_tests.WebAPI.Models;

public class StatisticPreviewResponse
{
    public Guid Id { get; set; }
    public DateTime AttemptTime { get; set; }
    public int CorrectAnswers { get; set; }
}