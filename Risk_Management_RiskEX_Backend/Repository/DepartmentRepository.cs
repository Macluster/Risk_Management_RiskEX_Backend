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
                // Map the DTO to the entity
                var department = _mapper.Map<Department>(departmentDto);

                // Add the entity to the database
                await _db.Departments.AddAsync(department);
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
