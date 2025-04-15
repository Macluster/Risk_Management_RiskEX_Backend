using System.ComponentModel.DataAnnotations;
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





        [HttpPost("add/quality")]
        public async Task<IActionResult> AddQualityRisk([FromBody] RiskDTO riskDto)
        {
            try
            {
                // Call the service method to add the Risk with its associated RiskAssessments and Reviews
                var newRisk = await _riskRepository.AddQualityRiskAsync(riskDto);

                // Return the newly created Risk object as a response
                return CreatedAtAction(nameof(AddQualityRisk), new { id = newRisk.Id }, newRisk);
            }
            catch (ValidationException valEx)
            {
                var errors = new Dictionary<string, List<string>>();

                foreach (var failure in valEx.ValidationResult.MemberNames)
                {
                    if (!errors.ContainsKey(failure))
                    {
                        errors[failure] = new List<string>();
                    }
                    errors[failure].Add(valEx.ValidationResult.ErrorMessage);
                }

                return BadRequest(new
                {
                    message = "Validation failed. Please correct the errors and try again.",
                    errors = errors
                });
            }
            catch (DbUpdateException dbEx)  // Handle database errors specifically
            {
                string errorMessage = dbEx.InnerException?.Message ?? dbEx.Message;

                // Common DB error handling
                string userFriendlyMessage;
                if (errorMessage.Contains("Cannot insert the value NULL", StringComparison.OrdinalIgnoreCase))
                {
                    userFriendlyMessage = "Please fill in all required fields.";
                }
                else if (errorMessage.Contains("FOREIGN KEY constraint", StringComparison.OrdinalIgnoreCase))
                {
                    userFriendlyMessage = "There seems to be a problem with a related record. Please check your input.";
                }
                else if (errorMessage.Contains("UNIQUE constraint", StringComparison.OrdinalIgnoreCase))
                {
                    userFriendlyMessage = "Duplicate entry: The data you're trying to save already exists.";
                }
                else
                {
                    userFriendlyMessage = "A database error occurred while saving your data. Please try again.";
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = userFriendlyMessage,
                    details = errorMessage
                });
            }
            catch (Exception ex) // General error handling
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An unexpected error occurred while processing your request.Please ensure all mandatory fields are filled. If the issue persists, contact the administrator or Please try again later",
                    //details = ex.Message
                });
            }
        }




        [HttpPost("add/securityOrPrivacy")]
        public async Task<IActionResult> AddRisk([FromBody] RiskDTO riskDto)
        {
            try
            {
                var newRisk = await _riskRepository.AddSecurityOrPrivacyRiskAsync(riskDto);
                return CreatedAtAction(nameof(AddRisk), new { id = newRisk.Id }, newRisk);
            }
            catch (ValidationException valEx)
            {
                var errors = new Dictionary<string, List<string>>();

                foreach (var failure in valEx.ValidationResult.MemberNames)
                {
                    if (!errors.ContainsKey(failure))
                    {
                        errors[failure] = new List<string>();
                    }
                    errors[failure].Add(valEx.ValidationResult.ErrorMessage);
                }

                return BadRequest(new
                {
                    message = "Validation failed. Please correct the errors and try again.",
                    errors = errors
                });
            }
            catch (DbUpdateException dbEx)  // Handle database errors specifically
            {
                string errorMessage = dbEx.InnerException?.Message ?? dbEx.Message;

                // Common DB error handling
                string userFriendlyMessage;
                if (errorMessage.Contains("Cannot insert the value NULL", StringComparison.OrdinalIgnoreCase))
                {
                    userFriendlyMessage = "Please fill in all required fields.";
                }
                else if (errorMessage.Contains("FOREIGN KEY constraint", StringComparison.OrdinalIgnoreCase))
                {
                    userFriendlyMessage = "There seems to be a problem with a related record. Please check your input.";
                }
                else if (errorMessage.Contains("UNIQUE constraint", StringComparison.OrdinalIgnoreCase))
                {
                    userFriendlyMessage = "Duplicate entry: The data you're trying to save already exists.";
                }
                else
                {
                    userFriendlyMessage = "A database error occurred while saving your data. Please try again.";
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = userFriendlyMessage,
                    details = errorMessage
                });
            }
            catch (Exception ex) // General error handling
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An unexpected error occurred. Please try again later.",
                    details = ex.Message
                });
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





        [HttpGet("RiskCategoryCountByDepartment")]
        public async Task<IActionResult> GetRiskCategoryCountsForDepartments([FromQuery] List<int> departmentIds, [FromQuery] List<int> projectIds)
        {
            var result = await _riskRepository.GetRiskCategoryCountsByDepartments(departmentIds, projectIds);
            return Ok(result);  // Return the results in JSON format
        }




        [HttpPut("edit/quality/{id}")]

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





        [HttpPut("edit/SecurityOrPrivacy/{id}")]
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
            catch (DbUpdateException dbEx)  // Handle database errors specifically
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Database update error occurred.",
                    details = dbEx.InnerException?.Message ?? dbEx.Message
                });
            }
            catch (ArgumentNullException argEx) // Handle missing required data
            {
                return BadRequest(new
                {
                    message = "Invalid input. Required fields are missing.",
                    details = argEx.Message
                });
            }
            catch (Exception ex) // General error handling
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An unexpected error occurred.",
                    details = ex.Message,
                    stackTrace = ex.StackTrace // Include stack trace for debugging
                });
            }
        }





        [HttpPut("update/quality/{riskId}")]
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




        [HttpPut("update/securityOrPrivacy/{riskId}")]
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


        [HttpGet("GetAllRisksAssigned")]
        public async Task<IActionResult> GetAllRisksAssigned()
        {


            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();


            try
            {


                var risks = await _riskRepository.GetAllRiskAssigned();
                return Ok(risks);

            }
            catch (Exception e)
            {
                return Ok("No user with the given Id");
            }


        }

        [HttpGet("GetRiskApproachingDeadline")]
        public async Task<IActionResult> RiskApproachingDeadline([FromQuery] List<int> departmentIds, [FromQuery] List<int> projectIds)
        {

            var risks = await _riskRepository.RiskApproachingDeadline(departmentIds, projectIds);
            return Ok(risks);
        }

        [HttpGet("GetRiskWithHeighestOverallRationg")]
        public async Task<IActionResult> GetRiskWithHeighestOverallRationg([FromQuery] List<int> departmentIds, [FromQuery] List<int> projectIds)
        {

            var risks = await _riskRepository.GetRiskWithHeighestOverallRationg(departmentIds, projectIds);
            return Ok(risks);
        }

        [HttpGet("CountOfRiskType(Open)")]
        public async Task<IActionResult> GetOpenRiskCountByType([FromQuery] List<int> departmentIds, [FromQuery] List<int> projectIds)
        {
            var riskTypeCounts = await _riskRepository.GetOpenRiskCountByType(departmentIds, projectIds);
            return Ok(riskTypeCounts);

        }

        [HttpGet("RiskCategory-Counts")]
        public async Task<IActionResult> GetRiskCategoryCounts(int? id)
        {
            var categoryCounts = await _riskRepository.GetRiskCategoryCounts(id);
            return Ok(categoryCounts);
        }



        [HttpGet("riskid/new/Id")]
        public async Task<ActionResult<string>> SetAndGetRiskId(int? departmentId = null, int? projectId = null)
        {
            try
            {
                if (departmentId.HasValue && projectId.HasValue)
                {
                    // Only one ID should be provided at a time
                    return BadRequest(new { message = "Please provide either DepartmentId or ProjectId, not both." });
                }

                if (!departmentId.HasValue && !projectId.HasValue)
                {
                    // At least one ID must be provided
                    return BadRequest(new { message = "Either DepartmentId or ProjectId is required." });
                }

                // Call the repository method with either departmentId or projectId
                string riskId = await _riskRepository.SetAndGetRiskIdAsync(departmentId, projectId);

                // Return the generated RiskId
                return Ok(new { riskId });
            }
            catch (ArgumentException ex)
            {
                // Handle invalid input
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                // Handle internal processing errors
                return StatusCode(500, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Catch-all for unexpected errors
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }



        [HttpPost("draft-quality")]
        public async Task<IActionResult> SaveDraft([FromBody] RiskDraftDTO riskDraftDto)
        {
            if (riskDraftDto == null)
            {
                return BadRequest("Risk data is required.");
            }

            try
            {
                var savedDraft = await _riskRepository.AddDraftQualityRiskAsync(riskDraftDto);
                return Ok(savedDraft); // return the saved draft back to the client
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                // You might want to log this exception in a real app
                return StatusCode(500, "An error occurred while saving the draft.");
            }
        }



        [HttpPost("Draft-security-or-privacy")]
        public async Task<IActionResult> SaveSecurityOrPrivacyDraft([FromBody] RiskDraftDTO riskDraftDto)
        {
            if (riskDraftDto == null)
            {
                return BadRequest("Risk data is required.");
            }

            try
            {
                var result = await _riskRepository.AddDraftSecurityOrPrivacyRiskAsync(riskDraftDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to save draft: {ex.Message}");
            }
        }


        [HttpGet("drafts")]
        public async Task<IActionResult> GetAllDrafts()
        {
            var drafts = await _riskRepository.GetAllDraftsAsync();
            return Ok(drafts);
        }


        [HttpDelete("drafts/{id}")]
        public async Task<IActionResult> DeleteDraft(string id)
        {
            var deleted = await _riskRepository.DeleteDraftByIdAsync(id); 
            if (!deleted)
                return NotFound("Draft not found.");

            return Ok("Draft deleted successfully.");
        }


        [HttpGet("drafts/department/{departmentId}")]
        public async Task<IActionResult> GetDraftsByDepartmentId(int departmentId)
        {
            var drafts = await _riskRepository.GetAllDraftsByDepartmentIdAsync(departmentId);
            return Ok(drafts);
        }

        [HttpGet("drafts/createdby/{createdBy}")]
        public async Task<IActionResult> GetDraftsByCreatedUser(int createdBy)
        {
            var drafts = await _riskRepository.GetAllDraftsByCreatedUserAsync(createdBy);
            return Ok(drafts);
        }





    }
}