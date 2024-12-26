using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;


namespace Risk_Management_RiskEX_Backend.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApplicationDBContext _db;

        public DepartmentRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _db.Departments.ToListAsync();
        }

        public async Task<bool> AddDepartment(Department department)
        {
            var result = await _db.Departments.AddAsync(department);
            await _db.SaveChangesAsync();
            if (result != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
