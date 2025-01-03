using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;

        public ReviewerController(IReviewerRepository reviewerRepository)
        {
            _reviewerRepository = reviewerRepository;
        }

        [HttpGet("getAllReviewers")]
        public async Task<ActionResult<AllReviewersResponseDto>> GetAllReviewers()
        {
            try
            {
                var reviewers = await _reviewerRepository.GetAllReviewersAsync();

                var response = new AllReviewersResponseDto
                {
                    Reviewers = reviewers
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add-reviewer")]
        public async Task<IActionResult> AddReviewer([FromBody] ExternalReviewerDTO externalReviewerDTO)
        {
            try
            {
                var reviewerId = await _reviewerRepository.AddNewReviewer(externalReviewerDTO);
                return Ok(new { ReviewerId = reviewerId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
