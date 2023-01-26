namespace TestPlatform.Application.DTOs;

public class AnswerOptionDTO
{
    public int OptionNumber { get; set; }

    public string OptionText { get; set; }

    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
}
