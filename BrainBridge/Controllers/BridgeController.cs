using BrainBridge.Models;
using BrainBridge.Services;
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
        public async Task<ActionResult<IEnumerable<Bridge>>> GetAllBridges()
        {
            var bridges = await _bridgeService.GetAllBridgesAsync();
            return Ok(bridges);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bridge>> GetBridgeById(int id)
        {
            var bridge = await _bridgeService.GetBridgeByIdAsync(id);
            if (bridge == null)
            {
                return NotFound();
            }
            return Ok(bridge);
        }

        [HttpPost]
        public async Task<ActionResult> AddBridge(Bridge bridge)
        {
            await _bridgeService.AddBridgeAsync(bridge);
            return CreatedAtAction(nameof(GetBridgeById), new { id = bridge.Id }, bridge);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBridge(int id, Bridge bridge)
        {
            if (id != bridge.Id)
            {
                return BadRequest();
            }
            await _bridgeService.UpdateBridgeAsync(bridge);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBridge(int id)
        {
            await _bridgeService.DeleteBridgeAsync(id);
            return NoContent();
        }
    }
}
