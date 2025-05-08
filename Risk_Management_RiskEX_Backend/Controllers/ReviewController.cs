using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Repository;


namespace Risk_Management_RiskEX_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController:ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }


        [HttpGet("GetReviewStatusOfARisk/{id}/{isPreReview}")]
        public async Task<IActionResult> GetReviewStatusOfARisk(int id,bool isPreReview)
        {
            try
            {
                var result = await _reviewRepository.GetReviewStatusOfARisk(id, isPreReview);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



    }
}
