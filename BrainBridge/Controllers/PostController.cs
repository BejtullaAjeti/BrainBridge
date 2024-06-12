using BrainBridge.DTOs;
using BrainBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PostDTO>> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddPost(PostDTO postDto)
        {
            await _postService.AddPostAsync(postDto);
            return CreatedAtAction(nameof(GetPostById), new { id = postDto.Id }, postDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> UpdatePost(int id, PostDTO postDto)
        {
            if (id != postDto.Id)
            {
                return BadRequest();
            }
            await _postService.UpdatePostAsync(postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
