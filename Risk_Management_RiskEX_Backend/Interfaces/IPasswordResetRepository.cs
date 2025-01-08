using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IPasswordResetRepository
    {
        Task<bool> SendPasswordResetEmailAsync(string email);
        Task<bool> ResetPasswordAsync(string token, string newPassword);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> ValidateResetTokenAsync(string token);
    }
}
