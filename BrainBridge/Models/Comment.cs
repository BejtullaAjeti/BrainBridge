namespace BrainBridge.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; } // Navigation property
        public int? ParentCommentId { get; set; } // For comment threading
        public Comment ParentComment { get; set; } // Navigation property
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } // Navigation property
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public ICollection<Comment> Replies { get; set; }
    }
}
