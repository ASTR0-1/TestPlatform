using AutoMapper;
using TestPlatform.Application.DTOs;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Mappers;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<User, UserDTO>().ReverseMap();

		CreateMap<Test, TestDTO>().ReverseMap();

		CreateMap<Question, QuestionDTO>().ReverseMap();

		CreateMap<AnswerOption, AnswerOptionDTO>().ReverseMap();

		CreateMap<UserTest, UserTestDTO>().ReverseMap();
	}
}
