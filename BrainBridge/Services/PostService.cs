using BrainBridge.Models;
using BrainBridge.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task AddPostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
