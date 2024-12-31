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

    }
}
