namespace create_test.Entities.Models;

public class Statistic : BaseEntity 
{
  public DateTime AttemptTime { get; set; }
  public int CorrectAnswers{ get; set; }
  public Guid UserId { get; set; }
  public virtual User User {get; set; }
  public Guid TestId { get; set; } 
  public virtual Test Test { get; set; }
}