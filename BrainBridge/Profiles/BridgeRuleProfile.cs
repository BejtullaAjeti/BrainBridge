using AutoMapper;
using BrainBridge.Models;
using BrainBridge.DTOs;

namespace BrainBridge.MappingProfiles
{
    public class BridgeRuleProfile : Profile
    {
        public BridgeRuleProfile()
        {
            CreateMap<BridgeRule, BridgeRuleDTO>().ReverseMap();
        }
    }
}
