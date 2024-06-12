namespace BrainBridge.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BridgeId { get; set; }
        public int CreatedById { get; set; }
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
