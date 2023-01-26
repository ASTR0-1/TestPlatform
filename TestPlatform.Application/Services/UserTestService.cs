using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Services;

public class UserTestService : IUserTestService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UserTestService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserTestDTO> GetByTestIdAsync(int testId)
    {
        var userTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: false);
        UserTest userTest = userTests.Where(ut => ut.TestId == testId).FirstOrDefault();

        if (userTest == null)
            throw new KeyNotFoundException();

        UserTestDTO userTestDTO = _mapper.Map<UserTest, UserTestDTO>(userTest);

        return userTestDTO;
    }

    public async Task<UserTestDTO> GetByUserEmailAsync(string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new KeyNotFoundException();

        var userTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: false);
        UserTest userTest = userTests.Where(ut => ut.UserId == user.Id).FirstOrDefault();
        if (userTest == null)
            throw new KeyNotFoundException();

        UserTestDTO userTestDTO = _mapper.Map<UserTest, UserTestDTO>(userTest);

        return userTestDTO;
    }

    public async Task<UserTestDTO> GetByUserIdAsync(int userId)
    {
        var userTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: false);
        UserTest userTest = userTests.Where(ut => ut.UserId == userId).FirstOrDefault();

        if (userTest == null)
            throw new KeyNotFoundException();

        UserTestDTO userTestDTO = _mapper.Map<UserTest, UserTestDTO>(userTest);

        return userTestDTO;
    }
}
