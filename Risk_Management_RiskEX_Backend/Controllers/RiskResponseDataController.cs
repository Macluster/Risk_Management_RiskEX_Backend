using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Repository;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskResponseDataController : ControllerBase
    {
        private readonly IRiskResponseRepository _responseRepository;
        public RiskResponseDataController(IRiskResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRiskResponses()
        {
            var riskResponses = await _responseRepository.GedtAllRiskResponse();
            return Ok(riskResponses);
        }

    }
}
