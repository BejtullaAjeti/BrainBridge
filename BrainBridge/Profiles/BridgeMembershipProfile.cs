using AutoMapper;
using BrainBridge.Models;
using BrainBridge.DTOs;

namespace BrainBridge.MappingProfiles
{
    public class BridgeMembershipProfile : Profile
    {
        public BridgeMembershipProfile()
        {
            CreateMap<BridgeMembership, BridgeMembershipDTO>().ReverseMap();
        }
    }
}
