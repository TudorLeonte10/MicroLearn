using MicroLearn.Dtos.Question;
using MicroLearn.Interfaces;
using MicroLearn.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace MicroLearn.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questions = await _questionRepository.GetAllAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            return Ok(question);
        }

        [HttpGet("concept/{conceptId}")]
        public async Task<IActionResult> GetByConceptId([FromRoute] int conceptId)
        {
            var questions = await _questionRepository.GetByConceptIdAsync(conceptId);
            return Ok(questions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto dto)
        {
            if (dto == null)
                return BadRequest("Payload missing");

            var createdQuestion = dto.ToQuestion();

            var question = await _questionRepository.CreateAsync(createdQuestion);

            return CreatedAtAction(nameof(GetById), new { id = question.Id }, question.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionDto dto, [FromRoute] int id)
        {
            var question = await _questionRepository.UpdateAsync(id, dto);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            var question = _questionRepository.DeleteAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
    }
}
