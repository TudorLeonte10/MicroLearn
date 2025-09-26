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
