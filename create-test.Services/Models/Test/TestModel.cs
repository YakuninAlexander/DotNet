using create_test.Entities.Models;

namespace create_test.Services.Models;

public class TestModel : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPrivate { get; set; }
    public DateTime CreateDate { get; set; }
    public int Popularity { get; set; }
    public int QuestionCount { get; set; }
}