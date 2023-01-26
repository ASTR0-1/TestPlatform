namespace TestPlatform.Domain.Entities;

public class Test
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int QuestionCount { get; set; }

    public IEnumerable<Question> Questions { get; set; } = new List<Question>();

    public IEnumerable<UserTest> UserTests { get; set; } = new List<UserTest>();
}
