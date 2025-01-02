using AutoMapper;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class GetUserRepository : IGetUserRepository

    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public GetUserRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        Task<bool> IGetUserRepository.GetAllUsers(GetUserDTO getUserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public IEnumerable<User> GetUsersByDepartment(int departmentId)
        {
            // Assuming you have a DbContext and a User entity with a DepartmentId property
            return _db.Users.Where(u => u.DepartmentId == departmentId).ToList();
        }

        public IEnumerable<User> GetUsersByProject(int projectId)
        {
           
            return _db.Projects
                             .Where(p => p.Id == projectId)
                             .Select(p => p.User)
                             .ToList();
        }

    }
}
