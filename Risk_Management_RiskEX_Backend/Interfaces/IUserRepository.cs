using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUserToDepartment(UsersDTO userDto, int? currentUserId = null);
        Task<bool> ChangeUserActiveStatus(int id, bool isActive);
        Task<Object> GetNameAndEmailOfAUser(int userId);
        Task<Object> GetInfoOfAssigneeByRiskId(int riskId);
        Task<List<User>> GetAllUsersWithDetailsAsync();
        //Task<IEnumerable<object>> GetUsersByDepartmentNameAsync(string departmentName);
        Task<List<User>> GetUsersByDepartmentNameAsync(string departmentName);



    }
}
