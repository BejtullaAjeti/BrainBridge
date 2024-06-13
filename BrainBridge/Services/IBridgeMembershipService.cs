using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public interface IBridgeMembershipService
    {
        Task<IEnumerable<BridgeMembershipDTO>> GetAllBridgeMembershipsAsync();
        Task<BridgeMembershipDTO> GetBridgeMembershipByIdAsync(int id);
        Task<BridgeMembershipDTO> GetMembershipByUserAndBridgeAsync(int userId, int bridgeId);
        Task AddBridgeMembershipAsync(BridgeMembershipDTO bridgeMembershipDto);
        Task UpdateBridgeMembershipAsync(BridgeMembershipDTO bridgeMembershipDto);
        Task DeleteBridgeMembershipAsync(int id);
    }
}
