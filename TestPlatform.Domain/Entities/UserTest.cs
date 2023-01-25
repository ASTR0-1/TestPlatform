namespace TestPlatform.Domain.Entities;

public class UserTest
{
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int TestId { get; set; }
    public Test Test { get; set; }

    public int Rating { get; set; }

    public string Answers { get; set; }
    
    public bool IsCompleted { get; set; }

    public DateTime FinishTime { get; set; }
}
