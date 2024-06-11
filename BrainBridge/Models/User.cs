using Microsoft.Extensions.Hosting;

namespace BrainBridge.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // e.g., "Regular", "Moderator", "Admin"
        public int Karma { get; set; } // User reputation score
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Bridge> ModeratedBridges { get; set; }
    }
}
