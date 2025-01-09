using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ResetPasswordDTO
    {
        [Required]
        public string ResetToken { get; set; } = string.Empty;  // Changed from Token to ResetToken

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
