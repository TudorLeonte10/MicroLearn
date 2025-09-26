using MicroLearn.Dtos.Concept;
using MicroLearn.Models;

namespace MicroLearn.Interfaces
{
    public interface IConceptRepository
    {
        Task<List<Concept>> GetAllConcepts();
        Task<Concept> GetConceptById(int id);
        Task<List<Concept>> GetConceptsByTopicId(int topicId);
        Task<Concept> CreateConceptAsync(Concept concept);
        Task<Concept> UpdateConceptAsync(int id, UpdateConceptDto updateConcept);
        Task<Concept> DeleteConceptAsync(int id);

    }
}
