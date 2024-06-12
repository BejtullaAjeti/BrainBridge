using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task AddPostAsync(PostDTO postDto);
        Task UpdatePostAsync(PostDTO postDto);
        Task DeletePostAsync(int id);
    }
}
