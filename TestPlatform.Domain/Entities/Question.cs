using System.ComponentModel.DataAnnotations;

namespace TestPlatform.Domain.Entities;

public class Question
{
    public int Id { get; set; }

    public int QuestionNumber { get; set; }

    public string QuestionText { get; set; }

    public int TestId { get; set; }
    public Test Test { get; set; }

    public IEnumerable<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
}
