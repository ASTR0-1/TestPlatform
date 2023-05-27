namespace TestPlatform.Application.DTOs;

public class SignUpDTO
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }

	public bool IsAdmin { get; set; }

	public string Password { get; set; }

	public string ConfirmPassword { get; set; }
}
