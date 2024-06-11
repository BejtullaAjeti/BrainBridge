namespace BrainBridge.Models
{
    public class Bridge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; }
        public ICollection<BridgeMembership> Members { get; set; }
        public ICollection<User> Moderators { get; set; }
        public ICollection<BridgeRule> Rules { get; set; }
    }
}
