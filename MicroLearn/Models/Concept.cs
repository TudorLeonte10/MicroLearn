namespace MicroLearn.Models
{
    public class Concept
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Question> Questions { get; set; } = new List<Question>();

        public int TopicId { get; set; } 
        public Topic Topic { get; set; } = null!;
    }
}
