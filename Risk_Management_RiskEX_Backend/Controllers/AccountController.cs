using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("ChangePassword/{userId}")]
        public async Task<IActionResult> ChangePassword(int userId, [FromBody] ChangePasswordRequestDTO request)
        {
            // Validate request
            if (string.IsNullOrEmpty(request.CurrentPassword) || string.IsNullOrEmpty(request.NewPassword) || string.IsNullOrEmpty(request.ConfirmPassword))
            {
                return BadRequest(new { message = "All fields are required." });
            }

            if (request.NewPassword != request.ConfirmPassword)
            {
                return BadRequest(new { message = "New Password and Confirm Password do not match." });
            }

            // Fetch the user from the database
            var user = await _accountRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            // Check if the current password matches the stored password (hashing recommended)
            if (user.Password != request.CurrentPassword) // Replace this with password hashing logic
            {
                return BadRequest(new { message = "Incorrect current password." });
            }

            // Update the password
            user.Password = request.NewPassword; // Replace this with password hashing logic
            await _accountRepository.UpdateUserPasswordAsync(user);

            return Ok(new { message = "Password changed successfully." });
        }
    }
}
