using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUserToDepartment(UsersDTO userDto);
        Task<bool> ChangeUserActiveStatus(int id, bool isActive);
        Task<dynamic> GetNameAndEmailOfAUser(int userId);
        Task<Object> GetNameAndEmailOfAUserbyRiskid(int riskId);
        Task<Object> GetInfoOfAssigneeByRiskId(int riskId);
        Task<List<User>> GetAllUsersWithDetailsAsync();
        Task<List<User>> GetUsersByDepartmentNameAsync(string departmentName);

        Task<List<User>> GetUsersByDepartmentIdAsync(int departmentId);

        Task<List<dynamic>> GetUsersByProjects(int[] projectIds);

        Task<bool> UpdateUser(int userId, UsersDTO userDto);

        Task<string> GetCreatedByUserNameAsync(string riskId);


        Task<int?> GetDepartmentIdByUserIdAsync(string userId);
        Task<List<int>> GetProjectIdsByUserIdAsync(string userId);
        Task<bool> IsUserActiveAsync(string userId);


    }
}
