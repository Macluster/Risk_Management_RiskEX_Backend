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

                // Use AutoMapper to map ProjectDTO to Project
                var project = _mapper.Map<Project>(projectDto);
                project.DepartmentId = department.Id;  // Set the DepartmentId manually

                _db.Projects.AddAsync(project);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log error (optional)
                // _logger.LogError(ex, "An error occurred while adding the project.");

                return false;
            }
        }


    }
}
