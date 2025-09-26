using MicroLearn.Dtos.User;
using MicroLearn.Interfaces;
using MicroLearn.Models;
using System.Security.Cryptography;
using BCrypt.Net;

namespace MicroLearn.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.EmailOrUsername))
                throw new ArgumentException("Email/Username is required");

            if (string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentException("Password is required");

            var user = await _userRepository.GetByEmailOrUsernameAsync(request.EmailOrUsername);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid Credentials");

            var ok = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!ok)
                throw new UnauthorizedAccessException("Wrong Password");

            user.LastLoginAt = DateTime.UtcNow;
            await _userRepository.Updateasync(user);

            var token = _jwtProvider.GenerateToken(user, DateTime.UtcNow, out var exp);

            return new AuthResponse
            {
                AccessToken = token,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.ToString(),
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentException("Username, Email and Password are mandatory.");
            }

            if (await _userRepository.EmailExistsAsync(request.Email))
                throw new InvalidOperationException("Email already in use");

            if (await _userRepository.UsernameExistsAsync(request.Username))
                throw new InvalidOperationException("Username already exists");

            var hashPass = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hashPass,
                Role = Role.User,
                CreatedAt = DateTime.UtcNow,
            };

            await _userRepository.AddAsync(user);

            var token = _jwtProvider.GenerateToken(user, DateTime.UtcNow, out var exp);

            return new AuthResponse
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.ToString(),
                AccessToken = token,
            };
        }
    }
}
