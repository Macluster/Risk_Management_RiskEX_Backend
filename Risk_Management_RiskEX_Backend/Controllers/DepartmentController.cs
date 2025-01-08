using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;


namespace RiskManagement_Department_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController:ControllerBase
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
           _departmentRepository = departmentRepository;

        }

        [HttpGet("Departments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            if (departments.Any())
            {
                return Ok(departments);
            }
            return NotFound("No departments found.");
        }
        [HttpPost("Department")]
        public async Task<IActionResult> AddDepartment([FromServices] IDepartmentRepository _departmentRepository, [FromBody] DepartmentDTO departmentDto)
        {
            try
            {
                if (string.IsNullOrEmpty(departmentDto.Name))
                {
                    return BadRequest(new { message = "Department name is required." });
                }

                var result = await _departmentRepository.AddDepartment(departmentDto);
                if (result)
                {
                    return Ok(new { message = "Department added successfully." });
                }

                return BadRequest(new { message = "Department already exists." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the department." });
            }
        }


        [HttpPut("Department")]
        public async Task<IActionResult> UpdateDepartment([FromServices] IDepartmentRepository _departmentRepository, [FromBody] DepartmentUpdateDTO departmentDto)
        {
            try
            {
                if (string.IsNullOrEmpty(departmentDto.DepartmentName))
                {
                    return BadRequest(new { message = "Department name is required." });
                }

                var result = await _departmentRepository.UpdateDepartment(departmentDto);
                if (result)
                {
                    return Ok(new { message = "Department updated successfully." });
                }

                return BadRequest(new { message = "not able to update" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the department." });
            }
        }

    }
}
