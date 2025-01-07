using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
    public class RiskController:ControllerBase
    {
        private readonly IRiskRepository _riskRepository;
        private readonly ILogger<RiskController> _logger;

        public RiskController(IRiskRepository riskRepository, ILogger<RiskController> logger)
        {
            _riskRepository = riskRepository;
            _logger = logger;
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


        //[HttpGet("reviewer")]
        //public async Task<ActionResult<IEnumerable<ApprovalDTO>>> GetRisksByReviewerId([FromQuery] int? userId)
        //{
        //    // Validate input
        //    if (!userId.HasValue)
        //    {
        //        return BadRequest("User ID must be provided.");
        //    }

        //    // Fetch risks using the repository
        //    var risks = await _riskRepository.GetRisksByReviewerAsync(userId.Value);

        //    if (risks == null || !risks.Any())
        //    {
        //        return NotFound("No risks found for the provided reviewer ID.");
        //    }

        //    // Return the risks in ApprovalDTO format
        //    return Ok(risks);
        //}





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
                var newRisk=  await _riskRepository.AddSecurityOrPrivacyRiskAsync(riskDto);
                return CreatedAtAction(nameof(AddRisk), new { id = newRisk.Id }, newRisk);
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
                if (risks != null)
                    return Ok(risks);
                else
                    return Ok(new List<Object>());
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

        [HttpGet("RiskCategory-Counts")]
        public async Task<IActionResult> GetRiskCategoryCounts()
        {
            var categoryCounts = await _riskRepository.GetRiskCategoryCounts();
            return Ok(categoryCounts);
        }

        [HttpGet("OpenRisk-Counts")]
        public async Task<IActionResult> GetOpenRiskCountByType()
        {
            var riskTypeCounts = await _riskRepository.GetOpenRiskCountByType();
            return Ok(riskTypeCounts);


            //var result = await _riskRepository.GetOpenRiskCountByType();     
            //return Ok(result);

        }

        [HttpGet("RiskCategoryCountByDepartment")]
        public async Task<IActionResult> GetRiskCategoryCountsForDepartments([FromQuery] List<int> departmentIds)
        {
            var result = await _riskRepository.GetRiskCategoryCountsByDepartments(departmentIds);
            return Ok(result);  // Return the results in JSON format
        }




        [HttpPut("quality/{id}")]
        public async Task<IActionResult> EditQualityRiskAsync(int id, [FromBody] RiskDTO riskDto)
        {


            if (riskDto == null)
            {
                return BadRequest("Risk data cannot be null.");
            }

            try
            {
                var updatedRisk = await _riskRepository.EditQualityRiskAsync(id, riskDto);
                return Ok(updatedRisk);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Risk with ID {id} not found.");
                return NotFound(new { Message = ex.Message });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating the database.");
                return StatusCode(500, new { Message = "An error occurred while updating the risk. Please try again later." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in EditQualityRiskAsync for RiskId: {RiskId}. RiskDTO: {@RiskDto}", id, riskDto);
                throw; // Re-throw the exception for the controller to handle.
            }
        }





        [HttpPut("SecurityOrPrivacy/{id}")]
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



        [HttpGet("GetRiskByAssigne")]
        public async Task<IActionResult> GetRiskByAssigneId(int? id)
        {


            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();


            try
            {
                if (id == null)
                {
                    // Validate and decode the token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadJwtToken(token);

                    // Extract claims from the token
                    var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    userId = jwtToken.Payload["nameid"].ToString();

                    var risks = await _riskRepository.GetRiskByAssigneeId(Int32.Parse(userId));
                    return Ok(risks);
                }
                else
                {
                    var risks = await _riskRepository.GetRiskByAssigneeId(id ?? 0);
                    return Ok(risks);
                }

            }
            catch (Exception e)
            {
                return Ok("No user with the given Id");
            }


        }

        [HttpGet("GetRiskApproachingDeadline")]
        public async Task<IActionResult> RiskApproachingDeadline(int? id)
        {

            var risks = await _riskRepository.RiskApproachingDeadline(id);
            return Ok(risks);
        }

        [HttpGet("GetRiskWithHeighestOverallRationg")]
        public async Task<IActionResult> GetRiskWithHeighestOverallRationg(int? id)
        {

            var risks = await _riskRepository.GetRiskWithHeighestOverallRationg(id);
            return Ok(risks);
        }
    }
}
