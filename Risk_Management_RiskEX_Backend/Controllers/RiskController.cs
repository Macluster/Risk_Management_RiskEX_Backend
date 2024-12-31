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
        public async Task<IActionResult> GetRisksByType(string type)
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

        [HttpGet("GetMitigationStatusOfARisk/{id}")]
        public async Task<IActionResult> GetMitigationStatusOfARisk(int id)
        {
            try
            {
                var result = await _riskRepository.GetMitigationStatusOfARisk(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("OverallRiskRating")]
        public async Task<IActionResult> GetOverallRiskRatings()
        {
        var riskRating = await _riskRepository.GetOverallRiskRating();
        return Ok(riskRating);
        }

        [HttpGet("OverallRiskRating/{id}")]
        public async Task<IActionResult> GetOverallRiskRatingById(int id)
        {
        var riskRating = await _riskRepository.GetOverallRiskRating(id);
        return Ok(riskRating);
        }
  }
}
