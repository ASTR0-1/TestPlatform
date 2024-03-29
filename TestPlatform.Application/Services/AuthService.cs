﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;
using TestPlatform.Domain.Exceptions;

namespace TestPlatform.Application.Services;

public class AuthService : IAuthService
{
	private readonly SignInManager<User> _signInManager;
	private readonly UserManager<User> _userManager;

	public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
	{
		_signInManager = signInManager;
		_userManager = userManager;
	}

	public async Task<User> SignIn(SignInDTO entity)
	{
		var user = await _userManager.Users
				.Include(u => u.UserTests)
				.FirstOrDefaultAsync(u => u.Email == entity.Email);

		if (user == null)
			throw new UserAuthenticationException($"Unknown user with email: {entity.Email}");

		var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, entity.Password);

		if (!isPasswordCorrect)
			throw new UserAuthenticationException($"Invalid password for user with email: {entity.Email}");

		await _userManager.UpdateSecurityStampAsync(user);
		await _signInManager.SignInAsync(user, true);

		return user;
	}

	public async Task SignOut()
	{
		await _signInManager.SignOutAsync();
	}

	public async Task<User> SignUp(SignUpDTO entity)
	{
		var user = new User
		{
			FirstName = entity.FirstName,
			LastName = entity.LastName,
			Email = entity.Email,
			UserName = entity.Email,
		};

		var result = await _userManager.CreateAsync(user, entity.Password);

		if (!result.Succeeded)
			throw new UserAuthenticationException(string.Join(';', result.Errors.Select(ie => ie.Description)));

		var currentUser = await _userManager.Users
			.Include(u => u.UserTests)
			.FirstOrDefaultAsync(u => u.Email == entity.Email);

		await _signInManager.SignInAsync(currentUser, true);

		return currentUser;
	}
}
