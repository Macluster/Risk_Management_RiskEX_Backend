using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Controllers
{
    [Route("api/password")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly ILogger<PasswordResetController> _logger;

        public PasswordResetController(
            IPasswordResetRepository passwordResetRepository,
            ILogger<PasswordResetController> logger)
        {
            _passwordResetRepository = passwordResetRepository;
            _logger = logger;
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                if (!await _passwordResetRepository.ValidateResetTokenAsync(resetPasswordDTO.Token))
                {
                    return BadRequest(new { message = "Invalid or expired reset token." });
                }

                var result = await _passwordResetRepository.ResetPasswordAsync(
                    resetPasswordDTO.Token,
                    resetPasswordDTO.NewPassword
                );

                if (result)
                {
                    return Ok(new { message = "Password has been reset successfully." });
                }
                return BadRequest(new { message = "Failed to reset password." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing password reset");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}

