using MicroLearn.Dtos.Concept;
using MicroLearn.Dtos.Topic;
using MicroLearn.Models;

namespace MicroLearn.Mappers
{
    public static class TopicMappers
    {
        public static TopicDto ToDto(this Topic topic) =>
    new TopicDto
    {
        Id = topic.Id,
        Name = topic.Name,
        Description = topic.Description,
        DomainId = topic.DomainId,
        Concepts = topic.Concepts.Select(c => new ConceptDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            TopicId = c.TopicId
        }).ToList()
    };

        public static Topic ToTopic(this CreateTopicDto dto) =>
            new Topic
            {
                Name = dto.Name,
                Description = dto.Description,
                DomainId = dto.DomainId
            };

    }
}
