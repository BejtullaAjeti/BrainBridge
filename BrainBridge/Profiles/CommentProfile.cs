using AutoMapper;
using BrainBridge.Models;
using BrainBridge.DTOs;

namespace BrainBridge.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}
