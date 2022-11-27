using create_test.Entities.Models;

namespace create_test.Services.Models;

public class StatisticModel : BaseModel
{
    public DateTime AttemptTime { get; set; }
    public int CorrectAnswers { get; set; }
}