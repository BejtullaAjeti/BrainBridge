namespace BrainBridge.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int? ParentCommentId { get; set; }
        public int CreatedById { get; set; }
        public int BridgeId { get; set; } // Assuming you have this property for authorization
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
