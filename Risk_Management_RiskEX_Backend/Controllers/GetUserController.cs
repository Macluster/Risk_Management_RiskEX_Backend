using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    public class GetUserController : ControllerBase

    {
        private IGetUserRepository _getUserRepository;

        public GetUserController(IGetUserRepository getUserRepository)
        {
            _getUserRepository = getUserRepository;

        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _getUserRepository.GetAllUsers();
            if (users.Any())
            {
                return Ok(users);
            }
            return NotFound("No users found.");
        }

        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _getUserRepository.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with ID {id} not found.");
        }

        [HttpGet("department/{departmentId}")]
        public IActionResult GetUsersByDepartment(int departmentId)
        {
            try
            {
                var users = _getUserRepository.GetUsersByDepartment(departmentId);
                if (!users.Any())
                {
                    return NotFound($"No users found in department with ID {departmentId}.");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("projects")]
        public IActionResult GetUsersByProjects([FromQuery] IEnumerable<int> projectIds)
        {
            try
            {
                var users = _getUserRepository.GetUsersByProjects(projectIds);
                if (!users.Any())
                {
                    return NotFound($"No users found for the provided project IDs.");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }



    }
}
