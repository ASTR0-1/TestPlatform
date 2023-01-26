using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlatform.Domain.Entities;

namespace TestPlatform.Application.Interfaces.Data;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetQuestionsAsync(bool trackChanges); 
    
    Task<Question> GetQuestionAsync(int id, bool trackChanges );

    void CreateQuestion(Question question);

    void UpdateQuestion(Question question);

    void DeleteQuestion(Question question);
}
