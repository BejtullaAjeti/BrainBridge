using BrainBridge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Repositories
{
    public interface IBridgeMembershipRepository : IGenericRepository<BridgeMembership>
    {
        Task<BridgeMembership> GetMembershipByUserAndBridgeAsync(int userId, int bridgeId);
    }
}
