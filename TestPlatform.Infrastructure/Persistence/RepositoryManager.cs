using TestPlatform.Application.Interfaces.Data;
using TestPlatform.Infrastructure.Persistence.Repositories;

namespace TestPlatform.Infrastructure.Persistence;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    private IAnswerOptionRepository _answerOptionRepository;
    private IQuestionRepository _questionRepository;
    private ITestRepository _testRepository;
    private IUserTestRepository _userTestRepository;

    private static readonly object _lock = new();

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
    }

    public IAnswerOptionRepository AnswerOption
    {
        get
        {
            lock (_lock)
            {
                _answerOptionRepository ??= new AnswerOptionRepository(_context);

                return _answerOptionRepository;
            }
        }
    }

    public IQuestionRepository Question
    {
        get
        {
            lock (_lock)
            {
                _questionRepository ??= new QuestionRepository(_context);

                return _questionRepository;
            }
        }
    }

    public ITestRepository Test
    {
        get
        {
            lock (_lock)
            {
                _testRepository ??= new TestRepository(_context);

                return _testRepository;
            }
        }
    }

    public IUserTestRepository UserTest
    {
        get
        {
            lock (_lock)
            {
                _userTestRepository ??= new UserTestRepository(_context);

                return _userTestRepository;
            }
        }
    }

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}
