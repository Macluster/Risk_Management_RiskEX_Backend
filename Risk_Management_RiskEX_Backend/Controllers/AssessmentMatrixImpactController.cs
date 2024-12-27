using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentMatrixImpactController : ControllerBase
    {
        private readonly IAssessmentMatrixImpactRepository _assessmentMatrixImpactRepository;
        public AssessmentMatrixImpactController(IAssessmentMatrixImpactRepository assessmentMatrixImpactRepository)
        {
            _assessmentMatrixImpactRepository = assessmentMatrixImpactRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllImpactDetails()
        {
            try
            {
                var impactDetails = await _assessmentMatrixImpactRepository.GetAllImpactData();
                if (impactDetails == null || !impactDetails.Any())
                {
                    return NotFound("No impact details found.");
                }

                return Ok(impactDetails);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while retrieving impact details. Please try again later.");
            }
        }

    }
}
