using MicroLearn.Data;
using MicroLearn.Dtos.Concept;
using MicroLearn.Interfaces;
using MicroLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLearn.Repositories
{
    public class ConceptRepository : IConceptRepository
    {
        private readonly AppDbContext _context;

        public ConceptRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Concept> CreateConceptAsync(Concept concept)
        {
            _context.Concepts.Add(concept);
            await _context.SaveChangesAsync();
            return concept;
        }

        public async Task<Concept> DeleteConceptAsync(int id)
        {
            var concept = await _context.Concepts.FindAsync(id);
            if (concept == null)
            {
                return null;
            }
            _context.Concepts.Remove(concept);
            await _context.SaveChangesAsync();
            return concept;

        }

        public async Task<List<Concept>> GetAllConcepts()
        {
            return await _context.Concepts.Include(c => c.Questions).ToListAsync();
        }

        public async Task<Concept> GetConceptById(int id)
        {
            return await _context.Concepts.Include(c => c.Questions).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Concept>> GetConceptsByTopicId(int topicId)
        {
            return await _context.Concepts.Include(c => c.Questions).Where(c => c.TopicId == topicId).ToListAsync();
        }

        public async Task<Concept> UpdateConceptAsync(int id, UpdateConceptDto updateConcept)
        {
            var concept = await _context.Concepts.FindAsync(id);
            if (concept == null)
            {
                return null;
            }

            concept.Name = updateConcept.Name;
            concept.Description = updateConcept.Description;
            concept.TopicId = updateConcept.TopicId;
            concept.Details = updateConcept.Details;
            concept.Recap = updateConcept.Recap;
            await _context.SaveChangesAsync();
            return concept;
        }
    }
}
