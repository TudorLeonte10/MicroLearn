// Models/User.cs
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;

namespace MicroLearn.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Username { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public Role Role { get; set; } = Role.User;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }
}
