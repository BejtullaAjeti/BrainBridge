namespace BrainBridge.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int? ParentCommentId { get; set; } // For comment threading
        public int CreatedById { get; set; }
        public int BridgeId { get; set; } // Assuming you have this property for authorization
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
