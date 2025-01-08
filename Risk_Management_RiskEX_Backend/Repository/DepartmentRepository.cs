using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;


namespace Risk_Management_RiskEX_Backend.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;


        public DepartmentRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _db.Departments.ToListAsync();
        }

        public async Task<bool> AddDepartment(DepartmentDTO departmentDto)
        {
            try
            {
                // Validate input: Check if department name is null or empty
                if (string.IsNullOrWhiteSpace(departmentDto.Name))
                {
                    throw new ArgumentException("Department name cannot be null or empty.");
                }

                // Check if department already exists
                var existingDepartment = await _db.Departments
                    .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == departmentDto.Name.ToLower());

                if (existingDepartment != null)
                {
                    return false;
                }

                // Map the DTO to the entity
                var department = _mapper.Map<Department>(departmentDto);
                department.DepartmentName = departmentDto.Name;

                // Add the entity to the database
                await _db.Departments.AddAsync(department);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (consider logging to a logging framework in production)
                Console.WriteLine($"Error adding department: {ex.Message}");
                throw; // Rethrow the exception to allow the controller or calling method to handle it
            }
        }

        public async Task<bool> UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO)
        {
            var department= await  _db.Departments.FirstOrDefaultAsync(e=>e.DepartmentName==departmentUpdateDTO.DepartmentName);
            department.DepartmentName = departmentUpdateDTO.NewDepartmentName;

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
