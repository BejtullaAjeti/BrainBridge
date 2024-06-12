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
    public class BridgeMembershipsController : ControllerBase
    {
        private readonly IBridgeMembershipService _bridgeMembershipService;

        public BridgeMembershipsController(IBridgeMembershipService bridgeMembershipService)
        {
            _bridgeMembershipService = bridgeMembershipService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BridgeMembershipDTO>>> GetAllBridgeMemberships()
        {
            var bridgeMemberships = await _bridgeMembershipService.GetAllBridgeMembershipsAsync();
            return Ok(bridgeMemberships);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BridgeMembershipDTO>> GetBridgeMembershipById(int id)
        {
            var bridgeMembership = await _bridgeMembershipService.GetBridgeMembershipByIdAsync(id);
            if (bridgeMembership == null)
            {
                return NotFound();
            }
            return Ok(bridgeMembership);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> AddBridgeMembership(BridgeMembershipDTO bridgeMembershipDto)
        {
            await _bridgeMembershipService.AddBridgeMembershipAsync(bridgeMembershipDto);
            return CreatedAtAction(nameof(GetBridgeMembershipById), new { id = bridgeMembershipDto.Id }, bridgeMembershipDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> UpdateBridgeMembership(int id, BridgeMembershipDTO bridgeMembershipDto)
        {
            if (id != bridgeMembershipDto.Id)
            {
                return BadRequest();
            }
            await _bridgeMembershipService.UpdateBridgeMembershipAsync(bridgeMembershipDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteBridgeMembership(int id)
        {
            await _bridgeMembershipService.DeleteBridgeMembershipAsync(id);
            return NoContent();
        }
    }
}
