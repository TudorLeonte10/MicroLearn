using MicroLearn.Dtos.Question;
using MicroLearn.Models;

namespace MicroLearn.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToDto(this Question question) =>
            new QuestionDto
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                QuestionType = question.QuestionType,
                OptionsJson = question.OptionsJson,
                CorrectAnswer = question.CorrectAnswer,
                ConceptId = question.ConceptId,
            };

        public static Question ToQuestion(this CreateQuestionDto dto) =>
            new Question
            {
                QuestionText = dto.QuestionText,
                QuestionType = dto.QuestionType,
                OptionsJson = dto.OptionsJson,
                CorrectAnswer = dto.CorrectAnswer,
                ConceptId = dto.ConceptId,
            };
    }
}
