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
    public class BridgeMembershipsController : ControllerBase
    {
        private readonly IBridgeMembershipService _bridgeMembershipService;
        private readonly IUserService _userService;
        private readonly IBridgeService _bridgeService;

        public BridgeMembershipsController(IBridgeMembershipService bridgeMembershipService, IUserService userService, IBridgeService bridgeService)
        {
            _bridgeMembershipService = bridgeMembershipService;
            _userService = userService;
            _bridgeService = bridgeService;
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
        [Authorize]
        public async Task<ActionResult> JoinBridge(int bridgeId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userService.GetUserByIdAsync(userId);
            var bridge = await _bridgeService.GetBridgeByIdAsync(bridgeId);

            if (bridge == null)
            {
                return NotFound(new { message = "Bridge not found" });
            }

            var bridgeMembershipDto = new BridgeMembershipDTO
            {
                BridgeId = bridgeId,
                UserId = userId,
                JoinedAt = DateTime.UtcNow,
                IsModerator = false
            };

            await _bridgeMembershipService.AddBridgeMembershipAsync(bridgeMembershipDto);
            return CreatedAtAction(nameof(GetBridgeMembershipById), new { id = bridgeMembershipDto.Id }, bridgeMembershipDto);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> LeaveBridge(int bridgeId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var membership = await _bridgeMembershipService.GetMembershipByUserAndBridgeAsync(userId, bridgeId);

            if (membership == null)
            {
                return NotFound(new { message = "Membership not found" });
            }

            await _bridgeMembershipService.DeleteBridgeMembershipAsync(membership.Id);
            return NoContent();
        }
    }
}
