using AutoMapper;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Services;

public class QuestionService : IQuestionService
{
	private readonly IRepositoryManager _repository;
	private readonly IMapper _mapper;

	public QuestionService(IRepositoryManager repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<QuestionDTO>> GetByTestId(int testId)
	{
		Test test = await _repository.Test.GetTestAsync(testId, trackChanges: false)
			?? throw new KeyNotFoundException($"There is no test with testId: {testId}");

		var questions = await _repository.Question.GetQuestionsAsync(trackChanges: false);
		var sortedQuestions = questions.Where(q => q.TestId == testId);

		var sortedQuestionsDTO = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(sortedQuestions);

		return sortedQuestionsDTO;
	}
}
