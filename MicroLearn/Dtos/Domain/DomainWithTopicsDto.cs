using MicroLearn.Dtos.Topic;

namespace MicroLearn.Dtos.Domain
{
    public class DomainWithTopicsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<TopicDto> Topics { get; set; } = new();
    }
}
