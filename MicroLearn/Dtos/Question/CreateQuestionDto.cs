namespace MicroLearn.Dtos.Question
{
    public class CreateQuestionDto
    {
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = "MCQ";
        public string? OptionsJson { get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
        public int ConceptId { get; set; }
    }
}
