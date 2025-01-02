using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RiskController : ControllerBase
  {
    private readonly IRiskRepository _riskRepository;

    public RiskController(IRiskRepository riskRepository)
    {
      _riskRepository = riskRepository;
    }
    [HttpGet("type/{type}")]
    public async Task<IActionResult> GetRisksByType(string type)
    {
      try
      {
        var risks = await _riskRepository.GetRisksByType(type);
        return Ok(risks);
      }
      catch (ArgumentException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }




    [HttpPost("Quality")]
    public async Task<IActionResult> AddQualityRisk([FromBody] RiskDTO riskDto)
    {
      try
      {
        // Call the service method to add the Risk with its associated RiskAssessments and Reviews
        var newRisk = await _riskRepository.AddQualityRiskAsync(riskDto);

        // Return the newly created Risk object as a response
        return CreatedAtAction(nameof(AddQualityRisk), new { id = newRisk.Id }, newRisk);
      }
      catch (Exception ex)
      {
        // Log the error or handle it as needed
        return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred: {ex.Message}");
      }
    }



    [HttpPost("security")]
    public async Task<IActionResult> AddRisk([FromBody] RiskDTO riskDto)
    {
      try
      {
        await _riskRepository.AddSecurityOrPrivacyRiskAsync(riskDto);
        return CreatedAtAction(nameof(AddRisk), new { }, riskDto);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"An error occurred: {ex.Message}");
      }
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetRisksById(int id)
    {
      try
      {
        var risks = await _riskRepository.GetRiskById(id);
        if (risks != null)
          return Ok(risks);
        else
          return Ok(new List<Object>());
      }
      catch (ArgumentException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpGet("GetMitigationStatusOfARisk/{id}")]
    public async Task<IActionResult> GetMitigationStatusOfARisk(int id)
    {
      try
      {
        var result = await _riskRepository.GetMitigationStatusOfARisk(id);
        return Ok(result);
      }
      catch (ArgumentException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpGet("OverallRiskRating")]
    public async Task<IActionResult> GetOverallRiskRatings()
    {
      var riskRating = await _riskRepository.GetOverallRiskRating();
      return Ok(riskRating);
    }

    [HttpGet("OverallRiskRating/{id}")]
    public async Task<IActionResult> GetOverallRiskRatingById(int id)
    {
      var riskRating = await _riskRepository.GetOverallRiskRating(id);
      return Ok(riskRating);
    }

    [HttpGet("RiskCategory-Counts")]
    public async Task<IActionResult> GetRiskCategoryCounts()
    {
      var categoryCounts = await _riskRepository.GetRiskCategoryCounts();
      return Ok(categoryCounts);
    }

    [HttpGet("OpenRisk-Counts")]
    public async Task<IActionResult> GetOpenRiskCountByType()
    {
      var riskTypeCounts = await _riskRepository.GetOpenRiskCountByType();
      return Ok(riskTypeCounts);


      //var result = await _riskRepository.GetOpenRiskCountByType();     
      //return Ok(result);

    }

    [HttpGet("RiskCategoryCountByDepartment")]
    public async Task<IActionResult> GetRiskCategoryCountsForDepartments([FromQuery] List<int> departmentIds)
    {
      var result = await _riskRepository.GetRiskCategoryCountsByDepartments(departmentIds);
      return Ok(result);  // Return the results in JSON format
    }
  }
}
