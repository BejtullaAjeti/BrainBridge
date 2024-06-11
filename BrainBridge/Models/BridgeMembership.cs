namespace BrainBridge.Models
{
    public class BridgeMembership
    {
        public int Id { get; set; }
        public int BridgeId { get; set; }
        public Bridge Bridge { get; set; } // Navigation property
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property
        public DateTime JoinedAt { get; set; }
        public bool IsModerator { get; set; }
    }
}
