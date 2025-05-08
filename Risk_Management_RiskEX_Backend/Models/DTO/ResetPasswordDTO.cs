using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
