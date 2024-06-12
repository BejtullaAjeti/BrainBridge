using AutoMapper;
using BrainBridge.Models;
using BrainBridge.Repositories;
using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task<CommentDTO> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task AddCommentAsync(CommentDTO commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.AddAsync(comment);
        }

        public async Task UpdateCommentAsync(CommentDTO commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }
    }
}
