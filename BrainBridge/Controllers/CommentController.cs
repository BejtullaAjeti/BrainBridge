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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
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
            await _commentService.AddCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetCommentById), new { id = commentDto.Id }, commentDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> UpdateComment(int id, CommentDTO commentDto)
        {
            if (id != commentDto.Id)
            {
                return BadRequest();
            }
            await _commentService.UpdateCommentAsync(commentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
