namespace TestPlatform.Application.DTOs;

public class QuestionDTO
{
	public int QuestionNumber { get; set; }

	public string QuestionText { get; set; }

	public int TestId { get; set; }

	public IEnumerable<AnswerOptionDTO> AnswerOptions { get; set; }
}
