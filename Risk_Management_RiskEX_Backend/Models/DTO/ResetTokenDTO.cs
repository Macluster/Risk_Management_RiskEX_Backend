namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ResetTokenDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }  // ✅ Ensure the token is received from frontend

    }
}
