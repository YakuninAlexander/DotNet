using create_test.Entities.Models;

namespace create_test.Services.Models;

public class CreateStatisticModel : BaseModel
{
  public Guid UserId { get; set; }
  public Guid TestId { get; set; }
  public DateTime AttemptTime { get; set; }
  public int CorrectAnswers { get; set; }
}