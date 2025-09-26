namespace MicroLearn.Dtos.User
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
