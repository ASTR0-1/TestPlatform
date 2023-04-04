namespace TestPlatform.Application.DTOs;

public class UserTestDTO
{
	public int UserId { get; set; }

	public int TestId { get; set; }

	public TestDTO Test { get; set; }

	public int Rating { get; set; }

	public string Answers { get; set; }

	public bool IsCompleted { get; set; }

	public DateTime FinishTime { get; set; }
}
