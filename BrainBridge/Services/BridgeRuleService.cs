using AutoMapper;
using BrainBridge.Models;
using BrainBridge.Repositories;
using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class BridgeRuleService : IBridgeRuleService
    {
        private readonly IBridgeRuleRepository _bridgeRuleRepository;
        private readonly IMapper _mapper;

        public BridgeRuleService(IBridgeRuleRepository bridgeRuleRepository, IMapper mapper)
        {
            _bridgeRuleRepository = bridgeRuleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BridgeRuleDTO>> GetAllBridgeRulesAsync()
        {
            var bridgeRules = await _bridgeRuleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BridgeRuleDTO>>(bridgeRules);
        }

        public async Task<BridgeRuleDTO> GetBridgeRuleByIdAsync(int id)
        {
            var bridgeRule = await _bridgeRuleRepository.GetByIdAsync(id);
            return _mapper.Map<BridgeRuleDTO>(bridgeRule);
        }

        public async Task AddBridgeRuleAsync(BridgeRuleDTO bridgeRuleDto)
        {
            var bridgeRule = _mapper.Map<BridgeRule>(bridgeRuleDto);
            await _bridgeRuleRepository.AddAsync(bridgeRule);
        }

        public async Task UpdateBridgeRuleAsync(BridgeRuleDTO bridgeRuleDto)
        {
            var bridgeRule = _mapper.Map<BridgeRule>(bridgeRuleDto);
            await _bridgeRuleRepository.UpdateAsync(bridgeRule);
        }

        public async Task DeleteBridgeRuleAsync(int id)
        {
            await _bridgeRuleRepository.DeleteAsync(id);
        }
    }
}
