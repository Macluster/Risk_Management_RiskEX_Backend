using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentMatrixLikelihoodController : ControllerBase
    {
        private readonly IAssessmentMatrixLikelihoodRepository _likelyhoodRepository;
        public AssessmentMatrixLikelihoodController(IAssessmentMatrixLikelihoodRepository likelyhoodRepository)
        {
            _likelyhoodRepository = likelyhoodRepository;
        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetAllLikelihoodDetails()
        {
            try
            {
                var likelihoodDetails = await _likelyhoodRepository.GetAllLikelyHoodData();

                if (likelihoodDetails == null || !likelihoodDetails.Any())
                {
                    return NotFound("No likelihood details found.");
                }

                return Ok(likelihoodDetails);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving likelihood details. Please try again later.");
            }
        }

    }
}
