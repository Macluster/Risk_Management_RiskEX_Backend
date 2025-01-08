using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    // ReportController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportService;

        public ReportController(IReportRepository reportRepository)
        {
            _reportService = reportRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDTO>>> GetReports(string? riskStatus = null)
        {
            try
            {
                var reports = await _reportService.GetAllRisk(riskStatus);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        [HttpGet("DepartmentwiseRisk/{id}")]
        public async Task<ActionResult<List<ReportDTO>>> GetReportsbyDepartment(int id, string? riskStatus = null)
        {
            try
            {
                var reports = await _reportService.GetAllRiskByDepartmentId(id, riskStatus);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


        [HttpGet("ClosedRisk")]
        public async Task<ActionResult<List<ReportDTO>>> GetAllClosedRisk()
        {
            try
            {
                var reports = await _reportService.GetAllClosedRisk();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        [HttpGet("projectrisks")]
        public async Task<IActionResult> GetRisksForUser([FromQuery] List<int> projectIds, string? riskStatus = null)
        {
            if (projectIds == null || !projectIds.Any())
            {
                return NotFound("No projects associated with this user.");
            }

            var risks = await _reportService.GetRisksByUserProjects(projectIds, riskStatus);
            return Ok(risks);
        }


    }
}
