namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ChangePasswordRequestDTO
    {
        public int UserId { get; set; } // Pass userId securely if needed, e.g., via JWT claims
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
