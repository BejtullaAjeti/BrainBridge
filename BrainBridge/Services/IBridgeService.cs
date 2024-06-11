using BrainBridge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public interface IBridgeService
    {
        Task<IEnumerable<Bridge>> GetAllBridgesAsync();
        Task<Bridge> GetBridgeByIdAsync(int id);
        Task<Bridge> GetBridgeByNameAsync(string name);
        Task AddBridgeAsync(Bridge bridge);
        Task UpdateBridgeAsync(Bridge bridge);
        Task DeleteBridgeAsync(int id);
    }
}
