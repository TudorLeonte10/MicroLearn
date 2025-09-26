using MicroLearn.Dtos.Question;


namespace MicroLearn.Dtos.Concept
{
    public class ConceptDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TopicId { get; set; }

        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
