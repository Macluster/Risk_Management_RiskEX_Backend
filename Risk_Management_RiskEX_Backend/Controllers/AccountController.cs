using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Services;

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
        public async Task<IActionResult> ChangePassword(int userId, [FromBody] ChangePasswordRequestDTO request, IPasswordService _passwordService)
        {
            if (string.IsNullOrEmpty(request.CurrentPassword) || string.IsNullOrEmpty(request.NewPassword) || string.IsNullOrEmpty(request.ConfirmPassword))
            {
                return BadRequest(new { message = "All fields are required." });
            }

            if (request.NewPassword != request.ConfirmPassword)
            {
                return BadRequest(new { message = "New Password and Confirm Password do not match." });
            }

            var user = await _accountRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            bool isPasswordVerified = _passwordService.VerifyPassword(user.Password, request.CurrentPassword);
            if (!isPasswordVerified)
            {
                return BadRequest(new { message = "Incorrect current password." });
            }

            user.Password=_passwordService.HashPassword(request.NewPassword) ;
            await _accountRepository.UpdateUserPasswordAsync(user);

            return Ok(new { message = "Password changed successfully." });
        }
    }
}
