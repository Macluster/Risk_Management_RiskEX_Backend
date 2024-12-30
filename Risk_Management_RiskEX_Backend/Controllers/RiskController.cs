using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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



        [HttpPost("Quality")]
        public async Task<IActionResult> AddQualityRisk([FromBody] RiskDTO riskDto)
        {
            try
            {
                // Call the service method to add the Risk with its associated RiskAssessments and Reviews
                var newRisk = await _riskRepository.AddQualityRiskAsync(riskDto);

                // Return the newly created Risk object as a response
                return CreatedAtAction(nameof(AddQualityRisk), new { id = newRisk.Id }, newRisk);
            }
            catch (Exception ex)
            {
                // Log the error or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred: {ex.Message}");
            }
        }




        [HttpPost("{riskType}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RiskResponseDTO>> CreateRisk([FromRoute] string riskType, [FromBody] RiskDTO riskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate and normalize risk type
                riskType = riskType.ToLower();
                if (riskType != "security" && riskType != "privacy")
                {
                    return BadRequest("Risk type must be either 'security' or 'privacy'");
                }

                // Set the risk name based on type
                riskDto.RiskName = $"{char.ToUpper(riskType[0]) + riskType.Substring(1)} Risk: {riskDto.RiskName}";

                // Set the risk type in the DTO
                riskDto.RiskType = riskType == "security" ? "2" : "3"; // Assuming 1 for security, 2 for privacy

                var risk = await _riskRepository.AddRiskAsync(riskDto);
                var response = MapToResponseDTO(risk);

                return Created($"api/risk/{risk.Id}", response);
            }
            catch (ArgumentException ex)
            {
                Logger.LogWarning(ex, "Invalid input for risk creation");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating risk");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}
