namespace MicroLearn.Dtos.Topic
{
    public class CreateTopicDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DomainId { get; set; }
    }
}
