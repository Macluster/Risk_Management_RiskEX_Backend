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


        //[HttpPut("update-review/{riskId}")]
        //public async Task<IActionResult> UpdateReviewStatusAndComments(int riskId, [FromBody] ReviewUpdateDTO updateRequest)
        //{
        //    if (updateRequest == null)
        //    {
        //        return BadRequest("Invalid data.");
        //    }

        //    // Call the method to update the review status
        //    bool statusUpdated = await _approvalRepository.UpdateReviewStatusAsync(riskId, updateRequest.ApprovalStatus);
        //    if (!statusUpdated)
        //    {
        //        return NotFound("Risk or review not found for status update.");
        //    }

        //    // Call the method to update the review comment
        //    bool commentUpdated = await _approvalRepository.UpdateReviewCommentByRiskIdAsync(riskId, updateRequest.Comments);
        //    if (!commentUpdated)
        //    {
        //        return NotFound("Risk or review not found for comment update.");
        //    }

        //    return Ok("Review status and comments updated successfully.");
        //}

        [HttpPut("update-review/{riskId}")]
        public async Task<IActionResult> UpdateReviewStatusAndComments(int riskId, [FromBody] ReviewUpdateDTO updateRequest)
        {
            // Validate the request body
            if (updateRequest == null || string.IsNullOrWhiteSpace(updateRequest.ApprovalStatus))
            {
                return BadRequest(new { Message = "Invalid data. ApprovalStatus is required." });
            }

            // Update the review status
            var statusUpdated = await _approvalRepository.UpdateReviewStatusAsync(riskId, updateRequest.ApprovalStatus);
            if (!statusUpdated)
            {
                return NotFound(new { Message = "Risk or review not found for status update." });
            }

            // Update the review comment
            var commentUpdated = await _approvalRepository.UpdateReviewCommentByRiskIdAsync(riskId, updateRequest.Comments);
            if (!commentUpdated)
            {
                return NotFound(new { Message = "Risk or review not found for comment update." });
            }

            // Return success response
            return Ok(new { Message = "Review status and comments updated successfully." });
        }




    }
}
