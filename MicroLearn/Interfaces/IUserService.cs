using MicroLearn.Dtos.User;

namespace MicroLearn.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponse> LoginAsync(LoginRequestDto request);

    }
}
