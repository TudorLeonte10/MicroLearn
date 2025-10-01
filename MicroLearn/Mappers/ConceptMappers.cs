using MicroLearn.Dtos.Concept;
using MicroLearn.Dtos.Question;
using MicroLearn.Models;

namespace MicroLearn.Mappers
{
    public static class ConceptMappers
    {
        public static ConceptDto ToDto(this Concept concept) =>
        new ConceptDto
        {
            Id = concept.Id,
            Description = concept.Description,
            Name = concept.Name,
            TopicId = concept.TopicId,
            Details = concept.Details,
            Recap = concept.Recap,
            Questions = concept.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                QuestionType = q.QuestionType,
                OptionsJson = q.OptionsJson,
                CorrectAnswer = q.CorrectAnswer,
                ConceptId = q.ConceptId
            }).ToList()
        };

        public static Concept ToConcept(this CreateConceptDto dto) =>
            new Concept
            {
                Description = dto.Description,
                Name = dto.Name,
                TopicId = dto.TopicId,
                Details = dto.Details,
                Recap = dto.Recap
            };
    }
}
