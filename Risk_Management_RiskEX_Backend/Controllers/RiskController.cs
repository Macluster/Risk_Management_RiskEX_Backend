using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using RiskManagement_Department_API.Models;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskController:ControllerBase
    {
        private IRiskRepository _riskRepository;

        public RiskController(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddRisk([FromBody] Risk risk)
        {
            return Ok( await _riskRepository.addRisk(risk));
           
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRisk(int id)
        {
            return Ok(await _riskRepository.getRiskById(id));

        }
    }
}
