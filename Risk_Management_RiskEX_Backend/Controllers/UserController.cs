using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Services;

namespace Risk_Management_RiskEX_Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost("register")]
    
        public async Task<IActionResult> AddUserToDepartment([FromBody] UsersDTO userDto)
        {
          

            var result = await _userRepository.AddUserToDepartment(userDto);

            if (result!=0)
            {
                return Ok(new
                {
                    result= "User successfully added to department.",
                    id=result,
                });
            }

            return BadRequest("Failed to add user. Please check the logs for details.");
        }
        [HttpPatch("IsActive/{id}/{isActive}")]
        public async Task<IActionResult> ChangeUserIsActiveStatus(int id,bool isActive)
        {

            var result=await _userRepository.ChangeUserActiveStatus(id,isActive);
            if (result)
            {
                return Ok("User isActive status updated successfully ");
            }

            return BadRequest("Failed to patch user. Please check the logs for details.");
        }


        [HttpGet("GetEmailAndNameOfAUser/{id}")]

        public async Task<IActionResult> GetEmailAndNameOfAUser(int id)
        {

            var result = await _userRepository.GetNameAndEmailOfAUser(id);
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest("No user found with the Id");
        }

        [HttpGet("GetEmailAndNameOfAUserbyRiskId/{id}")]

        public async Task<IActionResult> GetEmailAndNameOfAUserByRiskId(int id)
        {

            var result = await _userRepository.GetNameAndEmailOfAUserbyRiskid(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("No user found with the Id");
        }


        [HttpGet("GetInfoOfAssigneeByRiskId/{id}")]
        public async Task<IActionResult> GetInfoOfAssigneeByRiskId(int id)
        {

            var result = await _userRepository.GetInfoOfAssigneeByRiskId(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("No Assignee found");
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsersWithDetailsAsync();

                var result = users.Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.IsActive,
                    Department = u.Department?.DepartmentName ?? "No Department",
                    Projects = u.Projects?.Select(p => p.Name).ToList() ?? new List<string>()
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUsersByDepartment/{departmentName}")]
        public async Task<IActionResult> GetUsersByDepartment(string departmentName)
        {
            try
            {
                
                var users = await _userRepository.GetUsersByDepartmentNameAsync(departmentName);

                if (users == null || !users.Any())
                {
                    return NotFound($"No users found for the department: {departmentName}");
                }

                var result = users.Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.IsActive,
                    Department = u.Department?.DepartmentName ?? "No Department",
                    Projects = u.Projects?.Select(p => p.Name).ToList() ?? new List<string>()
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetUsersByDepartmentId(int departmentId)
        {
            try
            {
                var users = await _userRepository.GetUsersByDepartmentIdAsync(departmentId);

                if (users == null || !users.Any())
                {
                    return NotFound($"No users found for the department with ID: {departmentId}");
                }

                var result = users.Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.IsActive,
                    Department = u.Department?.DepartmentName ?? "No Department",
                    Projects = u.Projects?.Select(p => p.Name).ToList() ?? new List<string>()
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("users-by-projects")]
        public async Task<IActionResult> GetUsersByProjects([FromQuery] int[] projectIds)
        {
            try
            {
                var users = await _userRepository.GetUsersByProjects(projectIds);

                if (!users.Any())
                {
                    return NotFound("No users found for the provided project IDs.");
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GetUsersByProjects: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var result = await _userRepository.UpdateUser(id, userDto);

            if (!result)
            {
                return BadRequest("User update failed. Email may be already in use or department is not valid");
            }

            return Ok(new { message = "User updated successfully." });
        }



    }
}

