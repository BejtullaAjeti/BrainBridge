using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public interface IBridgeRuleService
    {
        Task<IEnumerable<BridgeRuleDTO>> GetAllBridgeRulesAsync();
        Task<BridgeRuleDTO> GetBridgeRuleByIdAsync(int id);
        Task AddBridgeRuleAsync(BridgeRuleDTO bridgeRuleDto);
        Task UpdateBridgeRuleAsync(BridgeRuleDTO bridgeRuleDto);
        Task DeleteBridgeRuleAsync(int id);
    }
}
