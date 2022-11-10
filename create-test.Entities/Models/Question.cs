namespace create_test.Entities.Models;

public class Questions : BaseEntity 
{
  public string Question { get;set; }
  public string RightAnswers {get;set;}
  public string Answers {get;set;}
  public Guid TestId{ get; set; }
  public virtual Test Test { get; set; }
}