using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IAuthRepository
    {

       

        Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO);

       

    }
}
