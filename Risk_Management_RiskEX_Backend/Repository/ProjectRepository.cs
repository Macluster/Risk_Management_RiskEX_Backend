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
        private readonly IMapper _mapper;  // Injecting AutoMapper

        public ProjectRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper; // Assigning AutoMapper to the field
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
                            .Select(p => new { p.Id, p.Name })
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

                //// Check if user exists
                //var userExists = await _db.Users
                //    .AnyAsync(u => u.Id == projectDto.UserId);

                //if (!userExists)
                //{
                //    return false;
                //}

                // Map and set up the project
                var project = _mapper.Map<Project>(projectDto);
                project.DepartmentId = department.Id;
                project.Name = projectDto.ProjectName;
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

        public async Task<bool> UpdateProjectById(ProjectDTO projectDto,int id)
        {
           var project= await  _db.Projects.FirstOrDefaultAsync(e => e.Id == id);

            project.Name=projectDto.ProjectName;
            await _db.SaveChangesAsync();

            return true;

        }
    }
}
