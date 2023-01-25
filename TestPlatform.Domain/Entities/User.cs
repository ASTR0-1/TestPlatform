using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TestPlatform.Domain.Entities;

public class User : IdentityUser<int>
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public List<Test> Tests { get; set; } = new List<Test>();
}
