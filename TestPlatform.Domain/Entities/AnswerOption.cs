using System.ComponentModel.DataAnnotations;

namespace TestPlatform.Domain.Entities;

public class AnswerOption
{
    public int Id { get; set; }

    public int OptionNumber { get; set; }

    public string OptionText { get; set; }

    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
