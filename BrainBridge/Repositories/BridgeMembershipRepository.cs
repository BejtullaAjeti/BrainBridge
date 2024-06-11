using BrainBridge.Data;
using BrainBridge.Models;

namespace BrainBridge.Repositories
{
    public class BridgeMembershipRepository : Repository<BridgeMembership>, IBridgeMembershipRepository
    {
        public BridgeMembershipRepository(BrainBridgeDbContext context) : base(context)
        {
        }
    }
}
