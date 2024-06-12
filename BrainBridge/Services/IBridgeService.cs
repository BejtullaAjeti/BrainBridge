using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public interface IBridgeService
    {
        Task<IEnumerable<BridgeDTO>> GetAllBridgesAsync();
        Task<BridgeDTO> GetBridgeByIdAsync(int id);
        Task<BridgeDTO> GetBridgeByNameAsync(string name);
        Task AddBridgeAsync(BridgeDTO bridgeDto);
        Task UpdateBridgeAsync(BridgeDTO bridgeDto);
        Task DeleteBridgeAsync(int id);
    }
}
