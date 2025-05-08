using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Services;


namespace Risk_Management_RiskEX_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResetPassController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly PasswordService _passwordService;

        public ResetPassController(IAuthRepository authRepository, PasswordService passwordService)
        {
            _authRepository = authRepository;
            _passwordService = passwordService;
        }

        // Save Reset Token (No email sending)
        [HttpPost("save-reset-token")]
        public async Task<IActionResult> SaveResetToken([FromBody] ResetTokenDTO model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Token))
            {
                return BadRequest(new { message = "Invalid request." });
            }

            // Save the token from frontend
            bool isTokenSaved = await _authRepository.SaveResetToken(model.Email, model.Token);
            if (!isTokenSaved)
            {
                return BadRequest(new { message = "Failed to save reset token." });
            }

            return Ok(new { message = "Reset token saved successfully." });
        }

        // ✅ Reset Password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Token) || string.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest(new { message = "Invalid request." });
            }

            // Validate the token
            bool isValidToken = await _authRepository.ValidateResetToken(model.Email, model.Token);
            if (!isValidToken)
            {
                return BadRequest(new { message = "Invalid or expired reset token." });
            }

            // Hash new password
            string hashedPassword = _passwordService.HashPassword(model.NewPassword);

            // Update user's password
            bool isPasswordUpdated = await _authRepository.UpdateUserPassword(model.Email, hashedPassword);
            if (!isPasswordUpdated)
            {
                return BadRequest(new { message = "Failed to reset password." });
            }

            return Ok(new { message = "Password reset successfully." });
        }
    }
}
