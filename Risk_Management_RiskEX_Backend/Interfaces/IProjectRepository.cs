using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<object>> GetProjectsByDepartment(string departmentName);

        Task<IEnumerable<object>> GetProjectsByDepartmentId(int departmentId);
        Task<bool> AddProjectToDepartment(ProjectDTO projectDto);

        Task<bool> UpdateProjectById(ProjectUpdateRequestDTO projectDto);

        Task<Project> GetProjectById(int id);


    }
}
