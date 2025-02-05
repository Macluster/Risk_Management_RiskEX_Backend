using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Services;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IAuthRepository
    {

       

        Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO,PasswordService _passwordService);

        Task<bool> SaveResetToken(string email, string token);
        Task<bool> ValidateResetToken(string email, string token);
        Task<bool> UpdateUserPassword(string email, string newPasswordHash);

    }
}
