using AutoMapper;
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

    public async Task<TestDTO> GetByTestId(int testId)
    {
        var test = await _repository.Test.GetTestAsync(testId, trackChanges: false)
            ?? throw new KeyNotFoundException($"Test with id '{testId}' doesn't exist");

        var testDto = _mapper.Map<Test, TestDTO>(test);

        return testDto;
    }

	public async Task<int> GetResultAsync(int testId, string email, int[] answers)
	{
		User user = await _userManager.FindByEmailAsync(email)
			?? throw new KeyNotFoundException($"User with email \"{email}\" doesn't exist");

		Test test = await _repository.Test.GetTestAsync(testId, trackChanges: false)
			?? throw new KeyNotFoundException($"Test with id '{testId}' doesn't exist");

		IEnumerable<UserTest> userTests = await _repository.UserTest.GetUserTestsAsync(trackChanges: true);
		UserTest userTest = userTests.Where(ut => ut.User.Id == user.Id && ut.TestId == testId).FirstOrDefault()
			?? throw new KeyNotFoundException($"UserTest with given UserId: '{user.Id}' and TestId: '{testId}' doesn't exist");

		if (userTest.IsCompleted)
			throw new InvalidOperationException("Can't get a result for completed test");

		int result = CalculateTestResult(test, answers);
		userTest.Answers = string.Join("", answers);
		userTest.Rating = result;
		userTest.FinishTime = DateTime.Now;
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
