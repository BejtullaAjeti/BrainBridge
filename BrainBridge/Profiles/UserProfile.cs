using AutoMapper;
using BrainBridge.Models;
using BrainBridge.DTOs;

namespace BrainBridge.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
