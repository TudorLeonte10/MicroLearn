namespace MicroLearn.Dtos.Concept
{
    public class CreateConceptDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TopicId { get; set; }
        public string? Details { get; set; }
        public string? Recap { get; set; }
    }
}
