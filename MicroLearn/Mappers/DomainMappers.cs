using MicroLearn.Dtos.Domain;
using MicroLearn.Models;
using MicroLearn.Dtos.Topic;

namespace MicroLearn.Mappers
{
    public static class DomainMappers
    {
        public static DomainDto ToDto(this Domain domain) =>
            new DomainDto
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description
            };

        public static Domain ToDomain(this CreateDomainDto dto) =>
            new Domain
            {
                Name = dto.Name,
                Description = dto.Description
            };

        public static DomainWithTopicsDto ToWithTopicsDto(this Domain domain)
        {
            return new DomainWithTopicsDto
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Topics = domain.Topics.Select (t => new TopicDto { 
                    Id = t.Id, 
                    Name = t.Name, 
                    Description = t.Description, 
                    DomainId = t.DomainId 
                }).ToList()
            };
        }
    }
}
