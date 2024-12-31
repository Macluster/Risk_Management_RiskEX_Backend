using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDBContext _db;

        public ReviewRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<object> GetReviewStatusOfARisk(int id, bool isPreReview)
        {
           
         
            if (isPreReview)
            {

                var assessments = await _db.Assessments.Where(e => e.RiskId == id && !e.IsMitigated)
               .Select(e => new
               {
                   actionBy = e.Review.User.FullName,
                   isReviewed = true,
                   date = e.Review.CreatedAt,
               }).ToListAsync();
                return assessments[0];
            }
            else
            {
                var assessments = await _db.Assessments.Where(e => e.RiskId == id && e.IsMitigated)
             .Select(e => new
             {
                 actionBy = e.Review.User.FullName,
                 isReviewed = true,
                 date = e.Review.CreatedAt,
             }).ToListAsync();
                return assessments[0];
            }
          
        }
    }
}
