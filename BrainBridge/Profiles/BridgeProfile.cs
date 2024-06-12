using AutoMapper;
using BrainBridge.Models;
using BrainBridge.DTOs;

namespace BrainBridge.MappingProfiles
{
    public class BridgeProfile : Profile
    {
        public BridgeProfile()
        {
            CreateMap<Bridge, BridgeDTO>().ReverseMap();
        }
    }
}
