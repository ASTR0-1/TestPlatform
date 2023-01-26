using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Identity;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Services;

public class TestService : ITestService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public TestService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IEnumerable<TestDTO>> GetByEmailAsync(string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new KeyNotFoundException();

        var tests = await _repository.Test.GetTestsAsync(trackChanges: false);
        var allUserTests = await _repository.UserTest.GetUserTestsAsync(false);

        var sortedTests = allUserTests
            .Where(ut => ut.User.Email == email)
            .Select(ut => ut.Test);
        if (sortedTests == null)
            throw new KeyNotFoundException();

        var sortedTestsDTO = _mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(sortedTests);

        return sortedTestsDTO;
    }

    public async Task<int> GetResultAsync(int testId, string email, int[] answers)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new KeyNotFoundException();

        Test test = await _repository.Test.GetTestAsync(testId, trackChanges: false);
        if (test == null)
            throw new KeyNotFoundException();

        IEnumerable<UserTest> userTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: true);
        UserTest userTest = userTests.Where(ut => ut.User.Id == user.Id && ut.TestId == testId).FirstOrDefault();
        if (userTest == null)
            throw new KeyNotFoundException();

        if (userTest.IsCompleted)
            throw new InvalidOperationException();

        int result = CalculateTestResult(test, answers);
        userTest.Answers = String.Join("", answers);
        userTest.Rating = result;
        userTest.IsCompleted = true;

        await _repository.SaveAsync();

        return result;
    }

    private int CalculateTestResult(Test test, int[] answers)
    {
        int result = 0;
        int questionCount = test.QuestionCount;

        var questions = test.Questions.ToList();

        for (int questionNumber = 0; questionNumber < questionCount; questionNumber++)
        {
            var answerOptions = questions[questionNumber].AnswerOptions;

            int correctAnswerNumber = questions[questionNumber].AnswerOptions
                .Where(ao => ao.IsCorrect == true)
                .FirstOrDefault()
                .OptionNumber;
            int currentAnswerNumber = answers[questionNumber];

            if (currentAnswerNumber == correctAnswerNumber)
                result++;
        }

        return result;
    }
}
