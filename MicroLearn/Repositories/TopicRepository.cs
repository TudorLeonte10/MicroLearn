using MicroLearn.Data;
using MicroLearn.Dtos.Topic;
using MicroLearn.Interfaces;
using MicroLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLearn.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _context;

        public TopicRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Topic> CreateTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic?> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return null;
            }
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return topic;
        }
        public async Task<List<Topic>> GetAllTopics()
        {
            return await _context.Topics
                .Include(t => t.Concepts)
                .ToListAsync();
        }

        public async Task<Topic?> GetTopicById(int id)
        {
            return await _context.Topics
                .Include(t => t.Concepts)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Topic>> GetTopicsByDomainId(int domainId)
        {
            return await _context.Topics
                .Include(t => t.Concepts)
                .Where(t => t.DomainId == domainId)
                .ToListAsync();
        }

        public async Task<Topic?> UpdateTopic(int id, UpdateTopicDto dto)
        {
            var existing = await _context.Topics.FindAsync(id);
            if (existing == null) return null;

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.DomainId = dto.DomainId;

            await _context.SaveChangesAsync();
            return existing;
        }

    }
}
