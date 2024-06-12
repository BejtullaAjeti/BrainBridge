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
    public class BridgeRulesController : ControllerBase
    {
        private readonly IBridgeRuleService _bridgeRuleService;

        public BridgeRulesController(IBridgeRuleService bridgeRuleService)
        {
            _bridgeRuleService = bridgeRuleService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BridgeRuleDTO>>> GetAllBridgeRules()
        {
            var bridgeRules = await _bridgeRuleService.GetAllBridgeRulesAsync();
            return Ok(bridgeRules);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BridgeRuleDTO>> GetBridgeRuleById(int id)
        {
            var bridgeRule = await _bridgeRuleService.GetBridgeRuleByIdAsync(id);
            if (bridgeRule == null)
            {
                return NotFound();
            }
            return Ok(bridgeRule);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> AddBridgeRule(BridgeRuleDTO bridgeRuleDto)
        {
            await _bridgeRuleService.AddBridgeRuleAsync(bridgeRuleDto);
            return CreatedAtAction(nameof(GetBridgeRuleById), new { id = bridgeRuleDto.Id }, bridgeRuleDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> UpdateBridgeRule(int id, BridgeRuleDTO bridgeRuleDto)
        {
            if (id != bridgeRuleDto.Id)
            {
                return BadRequest();
            }
            await _bridgeRuleService.UpdateBridgeRuleAsync(bridgeRuleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteBridgeRule(int id)
        {
            await _bridgeRuleService.DeleteBridgeRuleAsync(id);
            return NoContent();
        }
    }
}
