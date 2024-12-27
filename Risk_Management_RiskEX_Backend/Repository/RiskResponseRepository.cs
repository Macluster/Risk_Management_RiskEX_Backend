using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskResponseRepository : IRiskResponseRepository
    {
        private readonly ApplicationDBContext _db;
        public RiskResponseRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<ICollection<RiskResponseData>> GedtAllRiskResponse()
        {
            return await _db.RiskResponseDatas.ToListAsync();
        }
    }
}
