using MicroLearn.Dtos.Concept;
using MicroLearn.Dtos.Topic;
using MicroLearn.Interfaces;
using MicroLearn.Mappers;
using MicroLearn.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MicroLearn.Controllers
{
    [ApiController]
    [Route("api/concept")]
    public class ConceptController : ControllerBase
    {
        private readonly IConceptRepository _conceptRepository;
        public ConceptController(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var concepts = await _conceptRepository.GetAllConcepts();
            return Ok(concepts.Select(c => c.ToDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var concept = await _conceptRepository.GetConceptById(id);
            if (concept == null) {
                return NotFound();
            }
            return Ok(concept.ToDto());
        }

        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetByTopicId([FromRoute] int topicId)
        {
            var concepts = await _conceptRepository.GetConceptsByTopicId(topicId);
            return Ok(concepts.Select(c => c.ToDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConceptDto dto)
        {
            var created = dto.ToConcept();
            await _conceptRepository.CreateConceptAsync(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConcept([FromRoute] int id, [FromBody] UpdateConceptDto dto)
        {
            var concept = await _conceptRepository.UpdateConceptAsync(id, dto);
            if (concept == null)
            {
                return NotFound();
            }
            return Ok(concept);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _conceptRepository.DeleteConceptAsync(id);
            return NoContent();
        }
    }
}
