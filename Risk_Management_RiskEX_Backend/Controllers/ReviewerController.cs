using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewerController(IReviewerRepository reviewerRepository, IHttpContextAccessor httpContextAccessor)
        {
            _reviewerRepository = reviewerRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("getAllReviewers")]
        public async Task<ActionResult<AllReviewersResponseDto>> GetAllReviewers()
        {
            try
            {
                var reviewers = await _reviewerRepository.GetAllReviewersAsync(_httpContextAccessor);

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

        [HttpGet("gettheReviewer/{id}")]
        public async Task<IActionResult> GettheReviewer(int id,[FromQuery]string reviewStatus)
        {
            try
            {
                var reviewer = await _reviewerRepository.getthereviwer(id, reviewStatus);
                return Ok(reviewer);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.InnerException?.Message ?? ex.Message}");
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
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message }); // 409 Conflict
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
