using AutoMapper;
using BrainBridge.Models;
using BrainBridge.DTOs;

namespace BrainBridge.MappingProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}
