using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskRepository : IRiskRepository
    {
        private readonly ApplicationDBContext _db;
        public RiskRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Risk>> GetRisksByType(string type)
        {
            if (!Enum.TryParse(type, true, out RiskType riskType))
            {
                throw new ArgumentException($"Invalid RiskType value: {type}");
            }

            var risks = await _db.Risks
                .Where(r => r.RiskType == riskType)
                .ToListAsync();

            return risks;
        
    }
    }
}
