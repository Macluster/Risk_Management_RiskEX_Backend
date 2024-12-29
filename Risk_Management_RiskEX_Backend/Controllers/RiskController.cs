using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskController:ControllerBase
    {
        private readonly IRiskRepository _riskRepository;

        public RiskController(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetRisksByType(RiskType type)
        {
            try
            {
                var risks = await _riskRepository.GetRisksByType(type);
                return Ok(risks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("reviewer")]
        public async Task<ActionResult<IEnumerable<Risk>>> GetRisksByReviewerId([FromQuery] int? userId, [FromQuery] int? externalReviewerId)
        {
            // Validate that either userId or externalReviewerId is provided, but not both
            if (userId.HasValue && externalReviewerId.HasValue)
            {
                return BadRequest("Either userId or externalReviewerId must be provided, not both.");
            }

            if (!userId.HasValue && !externalReviewerId.HasValue)
            {
                return BadRequest("Either userId or externalReviewerId must be provided.");
            }

            // Fetch risks based on the provided reviewer ID
            var risks = await _riskRepository.GetRisksByReviewerIdAsync(userId, externalReviewerId);

            if (risks == null || !risks.Any())
            {
                return NotFound("No risks found for the provided reviewer ID.");
            }

            return Ok(risks);
        }
    }
}
