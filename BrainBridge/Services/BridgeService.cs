using AutoMapper;
using BrainBridge.Models;
using BrainBridge.Repositories;
using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class BridgeService : IBridgeService
    {
        private readonly IBridgeRepository _bridgeRepository;
        private readonly IMapper _mapper;

        public BridgeService(IBridgeRepository bridgeRepository, IMapper mapper)
        {
            _bridgeRepository = bridgeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BridgeDTO>> GetAllBridgesAsync()
        {
            var bridges = await _bridgeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BridgeDTO>>(bridges);
        }

        public async Task<BridgeDTO> GetBridgeByIdAsync(int id)
        {
            var bridge = await _bridgeRepository.GetByIdAsync(id);
            return _mapper.Map<BridgeDTO>(bridge);
        }

        public async Task<BridgeDTO> GetBridgeByNameAsync(string name)
        {
            var bridge = await _bridgeRepository.GetByNameAsync(name);
            return _mapper.Map<BridgeDTO>(bridge);
        }

        public async Task AddBridgeAsync(BridgeDTO bridgeDto)
        {
            var bridge = _mapper.Map<Bridge>(bridgeDto);
            await _bridgeRepository.AddAsync(bridge);
        }

        public async Task UpdateBridgeAsync(BridgeDTO bridgeDto)
        {
            var bridge = _mapper.Map<Bridge>(bridgeDto);
            await _bridgeRepository.UpdateAsync(bridge);
        }

        public async Task DeleteBridgeAsync(int id)
        {
            await _bridgeRepository.DeleteAsync(id);
        }
    }
}
