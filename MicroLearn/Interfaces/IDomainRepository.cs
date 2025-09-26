using MicroLearn.Dtos.Domain;
using MicroLearn.Models;

namespace MicroLearn.Interfaces
{
    public interface IDomainRepository
    {
        Task<List<Domain>> GetAllDomains();
        Task<IEnumerable<Domain>> GetAllWithTopics();
        Task<Domain?> GetDomainById(int id);
        Task<Domain> CreateDomain(Domain domain);
        Task<Domain?> UpdateDomain(int id, UpdateDomainDto dto);
        Task<Domain?> DeleteDomain(int id);
    }
}
