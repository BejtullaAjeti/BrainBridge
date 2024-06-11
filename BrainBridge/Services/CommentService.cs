using BrainBridge.Models;
using BrainBridge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _commentRepository.GetAllAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _commentRepository.GetByIdAsync(id);
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _commentRepository.AddAsync(comment);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }
    }
}
