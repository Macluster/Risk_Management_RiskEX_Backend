using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IGetUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> GetAllUsers(GetUserDTO getUserDTO);

    }
}
