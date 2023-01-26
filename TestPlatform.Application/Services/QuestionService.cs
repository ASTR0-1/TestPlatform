﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        Test test = await _repository.Test.GetTestAsync(testId, trackChanges: false);
        if (test == null)
            throw new KeyNotFoundException();

        var questions = await _repository.Question.GetQuestionsAsync(trackChanges: false);
        var sortedQuestions = questions.Where(q => q.TestId == testId);

        var sortedQuestionsDTO = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(sortedQuestions);

        return sortedQuestionsDTO;
    }
}