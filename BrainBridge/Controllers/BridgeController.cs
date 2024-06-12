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
    public class BridgesController : ControllerBase
    {
        private readonly IBridgeService _bridgeService;

        public BridgesController(IBridgeService bridgeService)
        {
            _bridgeService = bridgeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BridgeDTO>>> GetAllBridges()
        {
            var bridges = await _bridgeService.GetAllBridgesAsync();
            return Ok(bridges);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BridgeDTO>> GetBridgeById(int id)
        {
            var bridge = await _bridgeService.GetBridgeByIdAsync(id);
            if (bridge == null)
            {
                return NotFound();
            }
            return Ok(bridge);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> AddBridge(BridgeDTO bridgeDto)
        {
            await _bridgeService.AddBridgeAsync(bridgeDto);
            return CreatedAtAction(nameof(GetBridgeById), new { id = bridgeDto.Id }, bridgeDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> UpdateBridge(int id, BridgeDTO bridgeDto)
        {
            if (id != bridgeDto.Id)
            {
                return BadRequest();
            }
            await _bridgeService.UpdateBridgeAsync(bridgeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteBridge(int id)
        {
            await _bridgeService.DeleteBridgeAsync(id);
            return NoContent();
        }
    }
}
