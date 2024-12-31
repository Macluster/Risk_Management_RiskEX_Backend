using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskController : ControllerBase
    {
        private readonly IRiskRepository _riskRepository;
        private readonly ILogger<RiskController> _logger;

        public RiskController(IRiskRepository riskRepository, ILogger<RiskController> logger)
        {
            _riskRepository = riskRepository;
            _logger = logger;
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



        [HttpPost("security")]
        public async Task<IActionResult> AddRisk([FromBody] RiskDTO riskDto)
        {
            try
            {
                await _riskRepository.AddSecurityOrPrivacyRiskAsync(riskDto);
                return CreatedAtAction(nameof(AddRisk), new { }, riskDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
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



        [HttpPut("quality/{id}")]
        public async Task<IActionResult> EditQualityRiskAsync(int riskId, [FromBody] RiskDTO riskDto)
        {


            if (riskDto == null)
            {
                return BadRequest("Risk data cannot be null.");
            }

            try
            {
                var updatedRisk = await _riskRepository.EditQualityRiskAsync(riskId, riskDto);
                return Ok(updatedRisk);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Risk with ID {riskId} not found.");
                return NotFound(new { Message = ex.Message });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating the database.");
                return StatusCode(500, new { Message = "An error occurred while updating the risk. Please try again later." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in EditQualityRiskAsync for RiskId: {RiskId}. RiskDTO: {@RiskDto}", riskId, riskDto);
                throw; // Re-throw the exception for the controller to handle.
            }
        }





        [HttpPut("/{id}")]
        public async Task<IActionResult> EditSecurityOrPrivacyRiskAsync(int id, [FromBody] RiskDTO riskDto)
        {
            if (riskDto == null)
            {
                return BadRequest("Risk data is required.");
            }

            try
            {
                // Call the repository method to edit the risk
                var updatedRisk = await _riskRepository.EditSecurityOrPrivacyRiskAsync(id, riskDto);

                if (updatedRisk == null)
                {
                    // Return a 404 if the risk with the specified ID was not found
                    return NotFound($"Risk with ID {id} not found.");
                }

                // Return the updated risk in the response
                return Ok(updatedRisk);
            }
            catch (Exception ex)
            {
                // Return an internal server error if something goes wrong
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }





        [HttpPut("update/Quality/{riskId}")]
        public async Task<IActionResult> UpdateQualityRisk(int riskId, [FromBody] RiskUpdateDTO riskUpdateDto)
        {
            if (riskUpdateDto == null)
            {
                return BadRequest("Request data cannot be null.");
            }

            try
            {
                // Call the repository to update the risk
                var updatedRisk = await _riskRepository.UpdateQualityRiskAsync(riskId, riskUpdateDto);

                // Return success response
                return Ok(new
                {
                    Message = "Risk updated successfully.",
                    Data = updatedRisk
                });
            }
            catch (KeyNotFoundException ex)
            {
                // Handle not found scenario
                return NotFound(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while updating the risk.",
                    Details = ex.Message
                });
            }
        }




        [HttpPut("update/{riskId}")]
        public async Task<IActionResult> UpdateSecurityOrPrivacyRisk(int riskId, [FromBody] RiskUpdateDTO riskUpdateDto)
        {
            if (riskUpdateDto == null)
            {
                return BadRequest("Risk update data is required.");
            }

            try
            {
                var updatedRisk = await _riskRepository.UpdateSecurityOrPrivacyRiskAsync(riskId, riskUpdateDto);
                return Ok(updatedRisk); // Return the updated Risk
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while updating the risk.", details = ex.Message });
            }
        }
    }
}
