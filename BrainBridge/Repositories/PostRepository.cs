using BrainBridge.Data;
using BrainBridge.Models;

namespace BrainBridge.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BrainBridgeDbContext context) : base(context)
        {
        }
    }
}
