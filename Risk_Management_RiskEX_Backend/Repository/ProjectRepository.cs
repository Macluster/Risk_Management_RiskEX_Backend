using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProjectRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IEnumerable<object>> GetProjectsByDepartment(string departmentName)
        {
            var department = await _db.Departments
                                    .FirstOrDefaultAsync(d => d.DepartmentName == departmentName);
            if (department == null)
            {
                throw new Exception("Department does not exist.");
            }

            return await _db.Projects
                            .Where(p => p.DepartmentId == department.Id)
                            .Select(p => new { p.Id, p.Name, p.ProjectCode })
                            .ToListAsync();
        }
        public async Task<IEnumerable<object>> GetProjectsByDepartmentId(int departmentId)
        {
            var department = await _db.Departments
                                    .FirstOrDefaultAsync(d => d.Id == departmentId);
            if (department == null)
            {
                throw new Exception("Department does not exist.");
            }

            return await _db.Projects
                            .Where(p => p.DepartmentId == departmentId)
                            .Select(p => new { p.Id, p.Name, p.ProjectCode })
                            .ToListAsync();
        }
        public async Task<bool> AddProjectToDepartment(ProjectDTO projectDto)
        {
            try
            {
                // Check if department exists
                var department = await _db.Departments
                    .FirstOrDefaultAsync(d => d.DepartmentName == projectDto.DepartmentName);

                if (department == null)
                {
                    return false;
                }

                // Check if project name already exists in the department
                var existingProject = await _db.Projects
                    .AnyAsync(p => p.Name == projectDto.ProjectName &&
                                  p.DepartmentId == department.Id);

                if (existingProject)
                {
                    return false;
                }



                // Map and set up the project
                var project = _mapper.Map<Project>(projectDto);
                project.DepartmentId = department.Id;
                project.Name = projectDto.ProjectName;
                project.ProjectCode = projectDto.ProjectCode;
                project.CreatedAt = DateTime.UtcNow;
                project.UpdatedAt = DateTime.UtcNow;

                await _db.Projects.AddAsync(project);
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateProjectById(ProjectUpdateRequestDTO projectDto)
        {
            var project = await _db.Projects.FirstOrDefaultAsync(e => e.Name == projectDto.ProjectName);

            project.Name = projectDto.NewProjectName;
            project.ProjectCode = projectDto.NewProjectCode;
            await _db.SaveChangesAsync();

            return true;

        }
        public async Task<Project> GetProjectById(int id)
        {
            var project = await _db.Projects
                .Include(p => p.Department)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                throw new Exception("Project does not exist.");
            }

            return project;
        }
    }
}
