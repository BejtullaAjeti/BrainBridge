using BrainBridge.DTOs;
using BrainBridge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrainBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IBridgeService _bridgeService;

        public CommentsController(ICommentService commentService, IUserService userService, IBridgeService bridgeService)
        {
            _commentService = commentService;
            _userService = userService;
            _bridgeService = bridgeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CommentDTO>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddComment(CommentDTO commentDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            commentDto.CreatedById = userId;
            await _commentService.AddCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetCommentById), new { id = commentDto.Id }, commentDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateComment(int id, CommentDTO commentDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var comment = await _commentService.GetCommentByIdAsync(id);

            if (comment == null || comment.CreatedById != userId)
            {
                return Forbid("User is not authorized to edit this comment.");
            }

            if (id != commentDto.Id)
            {
                return BadRequest();
            }

            await _commentService.UpdateCommentAsync(commentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userService.GetUserByIdAsync(userId);
            var comment = await _commentService.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            var bridge = await _bridgeService.GetBridgeByIdAsync(comment.BridgeId); // Assuming comment has a BridgeId property

            if (comment.CreatedById == userId ||
                user.Role == "Admin" ||
                (user.Role == "Moderator" && bridge.Moderators.Any(m => m.Id == userId)))
            {
                await _commentService.DeleteCommentAsync(id);
                return NoContent();
            }

            return Forbid("User is not authorized to delete this comment.");
        }
    }
}
