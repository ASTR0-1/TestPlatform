using System.ComponentModel.DataAnnotations;

namespace TestPlatform.Domain.Entities;

public class AnswerOption
{
    public int Id { get; set; }

    [Required]
    public int OptionNumber { get; set; }

    [Required]
    public string OptionText { get; set; }

    [Required]
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }

    public Question Question { get; set; }
}
