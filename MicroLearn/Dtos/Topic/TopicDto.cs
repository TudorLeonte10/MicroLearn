namespace MicroLearn.Dtos.Topic
{
    public class TopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DomainId { get; set; }
    }
}
