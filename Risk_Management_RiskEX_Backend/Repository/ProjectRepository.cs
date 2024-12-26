using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;


namespace Risk_Management_RiskEX_Backend.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDBContext _db;

        public ProjectRepository(ApplicationDBContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Project>> GetProjectsByDepartment(string departmentName)
        {
            var department = await _db.Departments
                                      .FirstOrDefaultAsync(d => d.DepartmentName == departmentName);

            if (department == null)
            {
                throw new Exception("Department does not exist.");
            }

            return await _db.Projects
                            .Where(p => p.DepartmentId == department.Id)
            .ToListAsync();
        }

        public async Task<bool> AddProjectToDepartment(ProjectDTO projectDto)
        {
            try
            {
                var department = await _db.Departments
                                          .FirstOrDefaultAsync(d => d.DepartmentName == projectDto.DepartmentName);

                if (department == null)
                {
                    throw new Exception("Department does not exist.");
                }

                var project = new Project
                {
                    Name = projectDto.ProjectName,
                    DepartmentId = department.Id,
                    UserId = projectDto.UserId
                };

                _db.Projects.Add(project);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
