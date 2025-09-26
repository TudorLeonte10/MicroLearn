using MicroLearn.Models;

namespace MicroLearn.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user, DateTime nowUtc, out DateTime expiresAtUtc);
    }
}
