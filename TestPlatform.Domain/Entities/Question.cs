using System.ComponentModel.DataAnnotations;

namespace TestPlatform.Domain.Entities;

public class Question
{
    public int Id { get; set; }

    [Required]
    public int QuestionNumber { get; set; }

    [Required]
    public string QuestionText { get; set; }

    public int TestId { get; set; }

    public Test Test { get; set; }

    public List<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
}
