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

        

        public async Task<ICollection<Risk>> GetRisksByType(RiskType riskType)
        {
            //if (!Enum.TryParse(type, true, out RiskType riskType))
            //{
            //    throw new ArgumentException($"Invalid RiskType value: {type}");
            //}

            //var risks = await _db.Risks
            //    .Where(r => r.RiskType == riskType)
            //    .ToListAsync();

            //return risks;
         
            return await _db.Risks
                .Where(r => r.RiskType == riskType)
                .ToListAsync();
        
        
    }
        public async Task<IEnumerable<Risk>> GetRisksByReviewerIdAsync(int? userId, int? externalReviewerId)
        {

            if (userId.HasValue && externalReviewerId.HasValue)
            {
                throw new ArgumentException("Either userId or externalReviewerId must be null, not both.");
            }

            if (!userId.HasValue && !externalReviewerId.HasValue)
            {
                throw new ArgumentException("Either userId or externalReviewerId must be provided.");
            }

           
            IQueryable<Review> reviewsQuery = _db.Reviews.Include(r => r.RiskAssessments).ThenInclude(ra => ra.Risk);

            if (userId.HasValue)
            {
                reviewsQuery = reviewsQuery.Where(r => r.UserId == userId.Value);
            }
            else
            {
                reviewsQuery = reviewsQuery.Where(r => r.ExternalReviewerId == externalReviewerId.Value);
            }

            var reviews = await reviewsQuery.ToListAsync();

            if (reviews == null || reviews.Count == 0)
            {
                return new List<Risk>(); 
            }

            // Get all unique risks from the assessments
            var risks = reviews
                .SelectMany(r => r.RiskAssessments)
                .Select(ra => ra.Risk)
                .Distinct()
                .ToList();

            return risks;
        }

    }

    
}
