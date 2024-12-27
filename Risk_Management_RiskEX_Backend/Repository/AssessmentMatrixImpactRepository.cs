using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class AssessmentMatrixImpactRepository : IAssessmentMatrixImpactRepository
    {
        private readonly ApplicationDBContext _db;
        public AssessmentMatrixImpactRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<ICollection<AssessmentMatrixImpact>> GetAllImpactData()
        {
            return await _db.AssessmentsMatrixImpact.ToListAsync();
        }
    }
}
