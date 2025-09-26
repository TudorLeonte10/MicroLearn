namespace MicroLearn.Dtos.Topic
{
    public class UpdateTopicDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DomainId { get; set; }
    }
}
