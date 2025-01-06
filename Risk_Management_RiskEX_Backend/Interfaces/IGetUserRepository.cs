using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IGetUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);

        Task<bool> GetAllUsers(GetUserDTO getUserDTO);

        IEnumerable<User> GetUsersByDepartment(int departmentId);

        IEnumerable<User> GetUsersByProjects(IEnumerable<int> projectIds);
    }
}
