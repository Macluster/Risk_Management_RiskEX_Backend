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
            try
            {
                var projects = await _projectRepository.GetProjectsByDepartment(departmentName);
                return Ok(projects ?? Enumerable.Empty<object>());
            }
            catch (Exception ex)
            {
                return Ok(Enumerable.Empty<object>());  
            }
        }
        [HttpGet("projects/{departmentId}")]
        public async Task<IActionResult> GetProjectsByDepartmentId(int departmentId)
        {
            var projects = await _projectRepository.GetProjectsByDepartmentId(departmentId);
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

            return BadRequest( new { message = "An error occurred while adding the project." });
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProject([FromServices] IProjectRepository _projectRepository, [FromBody] ProjectUpdateRequestDTO projectDto,int id)
        {
            if (string.IsNullOrEmpty(projectDto.ProjectName))
            {
                return BadRequest(new { message = "Project name is required." });
            }

          

            var result = await _projectRepository.UpdateProjectById(projectDto);

            if (result)
            {
                return Ok(new { message = "Project Updated successfully." });
            }

            return StatusCode(500, new { message = "An error occurred while updating the project." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var project = await _projectRepository.GetProjectById(id);
                return Ok(new
                {
                    id = project.Id,
                    name = project.Name,
                    projectCode = project.ProjectCode,
                    departmentName = project.Department.DepartmentName
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
