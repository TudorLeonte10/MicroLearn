using MicroLearn.Data;
using MicroLearn.Dtos.Question;
using MicroLearn.Interfaces;
using MicroLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLearn.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Question> CreateAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> DeleteAsync(int id)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == id);
            if (question == null)
            {
                return null;
            }
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<List<Question>> GetByConceptIdAsync(int conceptId)
        {
            return await _context.Questions.Where(q => q.ConceptId == conceptId).ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question?> UpdateAsync(int id, UpdateQuestionDto updated)
        {
            var updatedQuestion = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (updatedQuestion == null)
            {
                return null;
            }

            updatedQuestion.QuestionText = updated.QuestionText;
            updatedQuestion.QuestionType = updated.QuestionType;
            updatedQuestion.OptionsJson = updated.OptionsJson;
            updatedQuestion.CorrectAnswer = updated.CorrectAnswer;
            updatedQuestion.ConceptId = updated.ConceptId;

            await _context.SaveChangesAsync();
            return updatedQuestion;
        }
    }
}
