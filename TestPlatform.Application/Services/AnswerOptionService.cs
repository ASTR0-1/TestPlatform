using AutoMapper;
using TestPlatform.Application.DTOs;
using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Application.Interfaces.Service;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Services;

public class AnswerOptionService : IAnswerOptionService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public AnswerOptionService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnswerOptionDTO>> GetByQuestionId(int questionId)
    {
        Question question = await _repository.Question.GetQuestionAsync(questionId, trackChanges: false);
        if (question == null)
            throw new KeyNotFoundException();

        var answerOptions = await _repository.AnswerOption.GetAnswerOptionsAsync(trackChanges: false);
        var sortedAnswerOptions = answerOptions.Where(ao => ao.QuestionId == questionId);

        var sortedAnswerOptionsDTO = _mapper.Map<IEnumerable<AnswerOption>, IEnumerable<AnswerOptionDTO>>(sortedAnswerOptions);

        return sortedAnswerOptionsDTO;
    }
}
