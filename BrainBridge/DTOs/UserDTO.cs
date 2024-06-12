namespace BrainBridge.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // e.g., "Regular", "Moderator", "Admin"
        public int Karma { get; set; } // User reputation score
        public string PasswordHash { get; set; } // Password hash
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
