using BrainBridge.Models;
using BrainBridge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class BridgeService : IBridgeService
    {
        private readonly IBridgeRepository _bridgeRepository;

        public BridgeService(IBridgeRepository bridgeRepository)
        {
            _bridgeRepository = bridgeRepository;
        }

        public async Task<IEnumerable<Bridge>> GetAllBridgesAsync()
        {
            return await _bridgeRepository.GetAllAsync();
        }

        public async Task<Bridge> GetBridgeByIdAsync(int id)
        {
            return await _bridgeRepository.GetByIdAsync(id);
        }

        public async Task<Bridge> GetBridgeByNameAsync(string name)
        {
            return await _bridgeRepository.GetByNameAsync(name);
        }

        public async Task AddBridgeAsync(Bridge bridge)
        {
            await _bridgeRepository.AddAsync(bridge);
        }

        public async Task UpdateBridgeAsync(Bridge bridge)
        {
            await _bridgeRepository.UpdateAsync(bridge);
        }

        public async Task DeleteBridgeAsync(int id)
        {
            await _bridgeRepository.DeleteAsync(id);
        }
    }
}
