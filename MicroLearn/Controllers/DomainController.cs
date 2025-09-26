using Microsoft.AspNetCore.Mvc;
using MicroLearn.Interfaces;
using MicroLearn.Mappers;
using MicroLearn.Dtos.Domain;

namespace MicroLearn.Controllers
{
    [ApiController]
    [Route("api/domain")]
    public class DomainController : ControllerBase
    {
        private readonly IDomainRepository _domainRepository;
        public DomainController(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDomains()
        {
            var domains = await _domainRepository.GetAllDomains();
            return Ok(domains.Select(d => d.ToWithTopicsDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDomainById([FromRoute] int id)
        {
            var domain = await _domainRepository.GetDomainById(id);
            if (domain == null)
            {
                return NotFound();
            }
            return Ok(domain.ToWithTopicsDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDomain([FromBody] CreateDomainDto dto)
        {
            var domain = dto.ToDomain();
            var createdDomain = await _domainRepository.CreateDomain(domain);
            return CreatedAtAction(nameof(GetDomainById), new { id = createdDomain.Id }, createdDomain.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDomain([FromRoute] int id, [FromBody] UpdateDomainDto dto)
        {
            var updatedDomain = await _domainRepository.UpdateDomain(id, dto);
            if (updatedDomain == null)
            {
                return NotFound();
            }
            return Ok(updatedDomain.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomain([FromRoute] int id)
        {
            var deletedDomain = await _domainRepository.DeleteDomain(id);
            if (deletedDomain == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
