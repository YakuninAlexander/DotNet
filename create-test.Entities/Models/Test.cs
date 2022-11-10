namespace create_test.Entities.Models;

public class Test : BaseEntity 
{
  public string Name {get;set;}
  public string Description {get;set;}
  public bool IsPrivate {get;set;}
  public DateTime CreateDate{get;set;}
  public int Popularity{get;set;}
  public int QuestionCount {get;set;}
  public Guid UserId{get;set;}
  public virtual User User{get;set;}
  public virtual ICollection<Statistic> Statistics { get; set; }
  public virtual ICollection<Questions> Questions { get; set; }

}