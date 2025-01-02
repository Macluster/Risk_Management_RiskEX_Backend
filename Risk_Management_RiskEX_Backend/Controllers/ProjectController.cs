using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Risk_Management_RiskEX_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController:ControllerBase
    {
        private IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
           
        }


        [HttpGet("ProjectsBy/{departmentName}")]
        public async Task<IActionResult> GetProjectsByDepartment(string departmentName)
        {
            var projects = await _projectRepository.GetProjectsByDepartment(departmentName);
            if (projects.Any())
            {
                return Ok(projects);
            }
            return NotFound("No projects found for the specified department.");
        }

        [HttpPost("Project")]
        [Authorize]
        public async Task<IActionResult> AddProject( [FromServices] IProjectRepository _projectRepository,[FromBody] ProjectDTO projectDto)
        {
            if (string.IsNullOrEmpty(projectDto.ProjectName))
            {
                return BadRequest(new { message = "Project name is required." });
            }

            if (string.IsNullOrEmpty(projectDto.DepartmentName))
            {
                return BadRequest(new { message = "Department name is required." });
            }

            var result = await _projectRepository.AddProjectToDepartment(projectDto);

            if (result)
            {
                return Ok(new { message = "Project added successfully." });
            }

            return StatusCode(500, new { message = "An error occurred while adding the project." });
        }

    }
}
