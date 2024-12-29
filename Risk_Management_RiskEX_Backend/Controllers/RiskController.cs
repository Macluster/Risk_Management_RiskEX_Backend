using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

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
        public async Task<ActionResult<IEnumerable<ApprovalDTO>>> GetRisksByReviewerId([FromQuery] int? userId)
        {
            // Validate input
            if (!userId.HasValue)
            {
                return BadRequest("User ID must be provided.");
            }

            // Fetch risks using the repository
            var risks = await _riskRepository.GetRisksByReviewerAsync(userId.Value);

            if (risks == null || !risks.Any())
            {
                return NotFound("No risks found for the provided reviewer ID.");
            }

            // Return the risks in ApprovalDTO format
            return Ok(risks);
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetRisksById(int id)
        {
            try
            {
                var risks = await _riskRepository.GetRiskById(id);
                return Ok(risks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
