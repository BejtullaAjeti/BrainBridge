namespace BrainBridge.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BridgeId { get; set; }
        public Bridge Bridge { get; set; } // Navigation property
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } // Navigation property
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Comment> Comments { get; set; }
    }
}
