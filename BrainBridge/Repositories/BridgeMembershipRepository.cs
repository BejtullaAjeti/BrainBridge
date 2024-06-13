using BrainBridge.Data;
using BrainBridge.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BrainBridge.Repositories
{
    public class BridgeMembershipRepository : GenericRepository<BridgeMembership>, IBridgeMembershipRepository
    {
        public BridgeMembershipRepository(BrainBridgeDbContext context) : base(context)
        {
        }

        public async Task<BridgeMembership> GetMembershipByUserAndBridgeAsync(int userId, int bridgeId)
        {
            return await _context.BridgeMemberships
                .FirstOrDefaultAsync(bm => bm.UserId == userId && bm.BridgeId == bridgeId);
        }
    }
}
