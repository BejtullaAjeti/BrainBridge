using BrainBridge.Data;
using BrainBridge.Models;

namespace BrainBridge.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BrainBridgeDbContext context) : base(context)
        {
        }
    }
}
