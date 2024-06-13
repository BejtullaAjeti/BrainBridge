using AutoMapper;
using BrainBridge.DTOs;
using BrainBridge.Models;
using BrainBridge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class BridgeMembershipService : IBridgeMembershipService
    {
        private readonly IBridgeMembershipRepository _bridgeMembershipRepository;
        private readonly IMapper _mapper;

        public BridgeMembershipService(IBridgeMembershipRepository bridgeMembershipRepository, IMapper mapper)
        {
            _bridgeMembershipRepository = bridgeMembershipRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BridgeMembershipDTO>> GetAllBridgeMembershipsAsync()
        {
            var memberships = await _bridgeMembershipRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BridgeMembershipDTO>>(memberships);
        }

        public async Task<BridgeMembershipDTO> GetBridgeMembershipByIdAsync(int id)
        {
            var membership = await _bridgeMembershipRepository.GetByIdAsync(id);
            return _mapper.Map<BridgeMembershipDTO>(membership);
        }

        public async Task<BridgeMembershipDTO> GetMembershipByUserAndBridgeAsync(int userId, int bridgeId)
        {
            var membership = await _bridgeMembershipRepository.GetMembershipByUserAndBridgeAsync(userId, bridgeId);
            return _mapper.Map<BridgeMembershipDTO>(membership);
        }

        public async Task AddBridgeMembershipAsync(BridgeMembershipDTO bridgeMembershipDto)
        {
            var membership = _mapper.Map<BridgeMembership>(bridgeMembershipDto);
            await _bridgeMembershipRepository.AddAsync(membership);
        }

        public async Task UpdateBridgeMembershipAsync(BridgeMembershipDTO bridgeMembershipDto)
        {
            var membership = _mapper.Map<BridgeMembership>(bridgeMembershipDto);
            await _bridgeMembershipRepository.UpdateAsync(membership);
        }

        public async Task DeleteBridgeMembershipAsync(int id)
        {
            await _bridgeMembershipRepository.DeleteAsync(id);
        }
    }
}
