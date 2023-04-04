using TestPlatform.Application.DTOs;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Interfaces.Service;

public interface IAuthService
{
	Task<User> SignUp(SignUpDTO entity);

	Task<User> SignIn(SignInDTO entity);

	Task SignOut();
}
