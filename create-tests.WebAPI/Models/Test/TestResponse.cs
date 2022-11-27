namespace create_tests.WebAPI.Models;

public class TestResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPrivate { get; set; }
    public DateTime CreateDate { get; set; }
    public int Popularity { get; set; }
    public int QuestionCount { get; set; }
}