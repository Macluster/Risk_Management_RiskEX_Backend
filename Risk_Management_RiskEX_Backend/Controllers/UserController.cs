using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

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
            // Get the current user's ID from your authentication context
          

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


        [HttpGet("GetEmailAndPasswordOfAUser/{id}")]

        public async Task<IActionResult> GetEmailAndPasswordOfAUser(int id)
        {

            var result = await _userRepository.GetNameAndEmailOfAUser(id);
            if (result!=null)
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



    }
}

