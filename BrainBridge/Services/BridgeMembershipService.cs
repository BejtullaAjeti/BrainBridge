using AutoMapper;
using BrainBridge.Models;
using BrainBridge.Repositories;
using BrainBridge.DTOs;
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
            var bridgeMemberships = await _bridgeMembershipRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BridgeMembershipDTO>>(bridgeMemberships);
        }

        public async Task<BridgeMembershipDTO> GetBridgeMembershipByIdAsync(int id)
        {
            var bridgeMembership = await _bridgeMembershipRepository.GetByIdAsync(id);
            return _mapper.Map<BridgeMembershipDTO>(bridgeMembership);
        }

        public async Task AddBridgeMembershipAsync(BridgeMembershipDTO bridgeMembershipDto)
        {
            var bridgeMembership = _mapper.Map<BridgeMembership>(bridgeMembershipDto);
            await _bridgeMembershipRepository.AddAsync(bridgeMembership);
        }

        public async Task UpdateBridgeMembershipAsync(BridgeMembershipDTO bridgeMembershipDto)
        {
            var bridgeMembership = _mapper.Map<BridgeMembership>(bridgeMembershipDto);
            await _bridgeMembershipRepository.UpdateAsync(bridgeMembership);
        }

        public async Task DeleteBridgeMembershipAsync(int id)
        {
            await _bridgeMembershipRepository.DeleteAsync(id);
        }
    }
}
