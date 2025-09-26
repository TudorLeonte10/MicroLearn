using MicroLearn.Dtos.Question;
using MicroLearn.Models;

namespace MicroLearn.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task<List<Question>> GetByConceptIdAsync(int conceptId);
        Task<Question> CreateAsync(Question question);
        Task<Question?> UpdateAsync(int id, UpdateQuestionDto updated);
        Task<Question> DeleteAsync(int id);
    }
}
