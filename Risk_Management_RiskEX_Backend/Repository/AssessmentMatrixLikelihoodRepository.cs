using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class AssessmentMatrixLikelihoodRepository : IAssessmentMatrixLikelihoodRepository
    {
        private readonly ApplicationDBContext _db;
        public AssessmentMatrixLikelihoodRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<ICollection<AssessmentMatrixLikelihood>> GetAllLikelyHoodData()
        {
            return await _db.AssessmentsMatrixLikelihood.ToListAsync();
        }
    }
}
