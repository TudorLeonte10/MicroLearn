namespace MicroLearn.Dtos.Concept
{
    public class UpdateConceptDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TopicId { get; set; }
    }
}
