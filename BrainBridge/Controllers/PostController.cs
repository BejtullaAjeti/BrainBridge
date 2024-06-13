using BrainBridge.DTOs;
using BrainBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrainBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IBridgeService _bridgeService;
        private readonly IUserService _userService;

        public PostsController(IPostService postService, IBridgeService bridgeService, IUserService userService)
        {
            _postService = postService;
            _bridgeService = bridgeService;
            _userService = userService;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserByIdAsync(int.Parse(userId));
            var bridge = await _bridgeService.GetBridgeByIdAsync(postDto.BridgeId);

            if (bridge == null || !user.ModeratedBridges.Any(b => b.Id == bridge.Id) && !bridge.Members.Any(m => m.UserId == user.Id))
            {
                return Forbid("User is not authorized to post in this bridge.");
            }

            postDto.CreatedById = user.Id;
            await _postService.AddPostAsync(postDto);
            return CreatedAtAction(nameof(GetPostById), new { id = postDto.Id }, postDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdatePost(int id, PostDTO postDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var post = await _postService.GetPostByIdAsync(id);

            if (post == null || post.CreatedById != int.Parse(userId))
            {
                return Forbid("User is not authorized to edit this post.");
            }

            if (id != postDto.Id)
            {
                return BadRequest();
            }

            await _postService.UpdatePostAsync(postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePost(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserByIdAsync(int.Parse(userId));
            var post = await _postService.GetPostByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            var bridge = await _bridgeService.GetBridgeByIdAsync(post.BridgeId);

            if (post.CreatedById == int.Parse(userId) ||
                user.Role == "Admin" ||
                (user.Role == "Moderator" && bridge.Moderators.Any(m => m.Id == user.Id)))
            {
                await _postService.DeletePostAsync(id);
                return NoContent();
            }

            return Forbid("User is not authorized to delete this post.");
        }
    }
}
