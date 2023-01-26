using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Application.Interfaces.Data;

public interface IRepositoryManager
{
    IAnswerOptionRepository AnswerOption { get; }
    IQuestionRepository Question { get; }
    ITestRepository Test { get; }
    IUserTestRepository UserTest { get; }

    Task SaveAsync();
}
