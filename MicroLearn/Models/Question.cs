namespace MicroLearn.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = "MCQ";
        public string? OptionsJson {  get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
        public int ConceptId { get; set; }
        public Concept Concept { get; set; } = null!;


    }
}
