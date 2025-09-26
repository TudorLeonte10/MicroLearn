using Microsoft.AspNetCore.Mvc;
using MicroLearn.Interfaces;
using MicroLearn.Dtos.Topic;
using MicroLearn.Mappers;

namespace MicroLearn.Controllers
{
    [ApiController]
    [Route("api/topic")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
        var topics  = await _topicRepository.GetAllTopics();
        return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById([FromRoute] int id)
        {
            var topic = await _topicRepository.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpGet("domain/{domainId}")]
        public async Task<IActionResult> GetTopicsByDomainId([FromRoute] int domainId)
        {
            var topics = await _topicRepository.GetTopicsByDomainId(domainId);
            if (topics == null || !topics.Any())
            {
                return NotFound();
            }
            return Ok(topics);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic([FromBody] CreateTopicDto dto)
        {
            var topic = dto.ToTopic();
            var createdTopic = await _topicRepository.CreateTopic(topic);
            return CreatedAtAction(nameof(GetTopicById), new { id = createdTopic.Id }, createdTopic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic([FromRoute] int id, [FromBody] UpdateTopicDto dto)
        {
            var topic = await _topicRepository.UpdateTopic(id, dto);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic([FromRoute] int id)
        {
            var topic = await _topicRepository.DeleteTopic(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }
    }
}

