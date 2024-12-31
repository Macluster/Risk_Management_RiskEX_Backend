using System.Security.Claims;
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
            int? currentUserId = User.Identity.IsAuthenticated
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
                : null;

            var result = await _userRepository.AddUserToDepartment(userDto, currentUserId);

            if (result)
            {
                return Ok("User successfully added to department.");
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


        [HttpGet("id")]

        public async Task<IActionResult> GetEmailAndPasswordOfAUser(int id)
        {

            var result = await _userRepository.GetNameAndEmailOfAUser(id);
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest("No user found with the Id");
        }





    }
}

