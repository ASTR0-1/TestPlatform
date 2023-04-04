namespace TestPlatform.Application.Interfaces.Data;

public interface IRepositoryManager
{
	IAnswerOptionRepository AnswerOption { get; }
	IQuestionRepository Question { get; }
	ITestRepository Test { get; }
	IUserTestRepository UserTest { get; }

	Task SaveAsync();
}
