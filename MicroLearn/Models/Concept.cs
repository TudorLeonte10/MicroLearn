namespace MicroLearn.Models
{
    public class Concept
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Details { get; set; }
        public string? Recap { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();

        public int TopicId { get; set; } 
        public Topic Topic { get; set; } = null!;
    }
}
