namespace BrainBridge.DTOs
{
    public class BridgeMembershipDTO
    {
        public int Id { get; set; }
        public int BridgeId { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool IsModerator { get; set; }
    }
}
