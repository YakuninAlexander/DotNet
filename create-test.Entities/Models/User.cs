namespace create_test.Entities.Models;

public class User : BaseEntity 
{
  public string Login {get;set;}
  public string PasswordHash{get;set;}
  public virtual ICollection<Statistic> Statistics { get; set; }
  public virtual ICollection<Test> Tests { get; set; }
}