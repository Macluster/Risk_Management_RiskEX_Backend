using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;

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

    }
}
