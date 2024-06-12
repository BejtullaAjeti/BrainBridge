using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetAllCommentsAsync();
        Task<CommentDTO> GetCommentByIdAsync(int id);
        Task AddCommentAsync(CommentDTO commentDto);
        Task UpdateCommentAsync(CommentDTO commentDto);
        Task DeleteCommentAsync(int id);
    }
}
