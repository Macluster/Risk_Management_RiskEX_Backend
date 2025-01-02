using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;

namespace Risk_Management_RiskEX_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController: ControllerBase
    {
        private readonly IApprovalRepository _approvalRepository;
        public ApprovalController(IApprovalRepository approvalRepository)
        {
            _approvalRepository = approvalRepository;
        }

        [HttpGet("Approval{userId}")]
        public async Task<ActionResult<IEnumerable<ApprovalDTO>>> GetRisksByReviewerId( int? userId)
        {
            // Validate input
            if (!userId.HasValue)
            {
                return BadRequest("User ID must be provided.");
            }

            // Fetch risks using the repository
            var risks = await _approvalRepository.GetRisksByReviewerAsync(userId);

            if (risks == null || !risks.Any())
            {
                return NotFound("No risks found for the provided reviewer ID.");
            }

            // Return the risks in ApprovalDTO format
            return Ok(risks);
        }

        [HttpGet("RisksToBeReviewed")]
        public async Task<IActionResult> GetRiskDetails()
        {
            try
            {
                var risks = await _approvalRepository.GetRiskDetailsToReviewAsync();
                if (!risks.Any())
                {
                    return NotFound("No risks found.");
                }
                return Ok(risks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPut("update-review-status")]
        public async Task<IActionResult> UpdateReviewStatusOnly(int riskId, string approvalStatus)
        {
            // Validate input
            if (string.IsNullOrEmpty(approvalStatus) || !new[] { "approved", "rejected" }.Contains(approvalStatus.ToLower()))
            {
                return BadRequest("Invalid approval status.");
            }

            // Update review status using repository
            bool updateSuccess = await _approvalRepository.UpdateReviewStatusAsync(riskId, approvalStatus);

            if (!updateSuccess)
            {
                return NotFound("Risk or review not found.");
            }

            return Ok("Review status updated successfully.");
        }
        [HttpPut("update-comment-by-risk")]
        public async Task<IActionResult> UpdateCommentByRiskId([FromQuery] int riskId, [FromBody] string comments)
        {
            // Validate inputs
            if (riskId <= 0 || string.IsNullOrWhiteSpace(comments))
                return BadRequest("Invalid risk ID or comments");

            // Attempt to update the review comment based on RiskId
            var result = await _approvalRepository.UpdateReviewCommentByRiskIdAsync(riskId, comments);

            if (result)
                return Ok(new { Message = "Comment updated successfully" });
            else
                return NotFound(new { Message = "Review not found for the provided RiskId" });
        }     
        //[HttpPut("update-comment-by-risk")]
        //public async Task<IActionResult> UpdatereviestatusByRiskId([FromQuery] int riskId, [FromBody] string approvalStatus ,[FromBody] string comments)
        //{
        //    // Validate inputs
        //    if (riskId <= 0 || string.IsNullOrWhiteSpace(comments))
        //        return BadRequest("Invalid risk ID or comments");

        //    // Attempt to update the review comment based on RiskId
        //    var result = await _approvalRepository.UpdateReviewStatusAsync(riskId, approvalStatus,comments);

        //    if (result)
        //        return Ok(new { Message = "Comment updated successfully" });
        //    else
        //        return NotFound(new { Message = "Review not found for the provided RiskId" });
        //}

        //[HttpPut("update-review-status-and-comments")]
        //public async Task<IActionResult> UpdateReviewStatusAndComments(int riskId, string approvalStatus, string comments)
        //{
        //    // Validate input
        //    if (string.IsNullOrEmpty(approvalStatus) || !new[] { "approved", "rejected" }.Contains(approvalStatus.ToLower()))
        //    {
        //        return BadRequest("Invalid approval status.");
        //    }

        //    // Call the service method to update both status and comments
        //    bool updateSuccess = await _approvalRepository.UpdateReviewStatusAsync(riskId, approvalStatus, comments);

        //    if (!updateSuccess)
        //    {
        //        return NotFound("Risk or review not found.");
        //    }

        //    return Ok("Review status and comments updated successfully.");
        //}


    }
}
