using MicroLearn.Models;

namespace MicroLearn.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailOrUsernameAsync(string emailOrUsername);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UsernameExistsAsync(string username);
        Task<User> AddAsync(User user);
        Task Updateasync(User user);
        Task<List<User>> GetAllAsync();
    }
}
