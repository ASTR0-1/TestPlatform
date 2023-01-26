﻿using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.DTOs;

public class TestDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int QuestionCount { get; set; }
}