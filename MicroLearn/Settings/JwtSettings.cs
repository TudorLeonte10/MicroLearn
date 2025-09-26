namespace MicroLearn.Settings
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty; // min. 32 chars
        public int ExpirationMinutes { get; set; } = 60;
    }
}
