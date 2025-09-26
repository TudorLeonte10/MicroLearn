using MicroLearn.Dtos.Topic;
using MicroLearn.Models;

namespace MicroLearn.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetAllTopics();
        Task<Topic?> GetTopicById(int id);
        Task<IEnumerable<Topic>> GetTopicsByDomainId(int domainId);
        Task<Topic> CreateTopic(Topic topic);
        Task<Topic?> UpdateTopic(int id, UpdateTopicDto dto);
        Task<Topic?> DeleteTopic(int id);

    }
}
