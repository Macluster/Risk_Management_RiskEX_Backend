using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using RiskManagement_Department_API.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskRepository : IRiskRepository
    {

        ApplicationDBContext _db;

        public RiskRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Object> addRisk(Risk risk)
        {
           return await  _db.Risks.AddAsync(risk);
        }

        public async Task<Risk> getRiskById(int id)
        {
            return  await _db.Risks.FirstOrDefaultAsync(u=>u.Id == id);
        }
    }
}
