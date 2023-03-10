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

    public async Task<IEnumerable<UserTestDTO>> GetByTestIdAsync(int testId)
    {
        var allUserTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: false);
        IEnumerable<UserTest> userTests = allUserTests.Where(ut => ut.TestId == testId);

        IEnumerable<UserTestDTO> userTestsDTO = _mapper.Map<IEnumerable<UserTest>, IEnumerable<UserTestDTO>>(userTests);

        return userTestsDTO;
    }

    public async Task<IEnumerable<UserTestDTO>> GetByUserEmailAsync(string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new KeyNotFoundException();

        var allUserTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: false);
        IEnumerable<UserTest> userTests = allUserTests.Where(ut => ut.UserId == user.Id);

        IEnumerable<UserTestDTO> userTestsDTO = _mapper.Map<IEnumerable<UserTest>, IEnumerable<UserTestDTO>>(userTests);

        return userTestsDTO;
    }

    public async Task<IEnumerable<UserTestDTO>> GetByUserIdAsync(int userId)
    {
        var allUserTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: false);
        IEnumerable<UserTest> userTests = allUserTests.Where(ut => ut.UserId == userId);

        IEnumerable<UserTestDTO> userTestsDTO = _mapper.Map<IEnumerable<UserTest>, IEnumerable<UserTestDTO>>(userTests);

        return userTestsDTO;
    }
}
