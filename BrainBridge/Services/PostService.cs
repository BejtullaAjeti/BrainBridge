using AutoMapper;
using BrainBridge.Models;
using BrainBridge.Repositories;
using BrainBridge.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task AddPostAsync(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.AddAsync(post);
        }

        public async Task UpdatePostAsync(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
