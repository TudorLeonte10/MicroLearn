using MicroLearn.Data;
using MicroLearn.Dtos;
using MicroLearn.Dtos.Domain;
using MicroLearn.Interfaces;
using MicroLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLearn.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        private readonly AppDbContext _context;

        public DomainRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Domain> CreateDomain(Domain domain)
        {
            _context.Domains.Add(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<Domain?> DeleteDomain(int id)
        {
            var domain = await _context.Domains.FindAsync(id);
            if (domain == null)
            {
                return null;
            }
            _context.Domains.Remove(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<List<Domain>> GetAllDomains()
        {
            return await _context.Domains.ToListAsync();
        }

        public async Task<Domain?> GetDomainById(int id)
        {
            return await _context.Domains.FindAsync(id);
        }

        public async Task<Domain?> UpdateDomain(int id, UpdateDomainDto dto)
        {
            var domain = _context.Domains.Find(id);
            if (domain == null)
            {
                return null;
            }

            domain.Name = dto.Name;
            domain.Description = dto.Description;

            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<IEnumerable<Domain>> GetAllWithTopics()
        {
            return await _context.Domains.Include(d => d.Topics).ToListAsync();
        }
    }
}
