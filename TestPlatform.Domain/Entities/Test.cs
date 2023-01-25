using System.ComponentModel.DataAnnotations;

namespace TestPlatform.Domain.Entities;

public class Test
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int QuestionCount { get; set; }

    public bool IsCompleted { get; set; } = false;

    public int UserId { get; set; }

    public User User { get; set; } 

    public List<Question> Questions { get; set; }
}
