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
                var responsiblePerson = await _db.Assessments.Where(e => e.RiskId == id && e.IsMitigated==false).Select(e => e.Review.User.FullName).FirstOrDefaultAsync();

                var assessments = await _db.Assessments.Where(e => e.RiskId == id && !e.IsMitigated)
               .Select(e => new
               {
                   actionBy = responsiblePerson,
                   isReviewed = e.Review.ReviewStatus,
                   date = e.Review.CreatedAt,
               }).FirstOrDefaultAsync();
                  return assessments != null ? assessments : new
                {
                    actionBy = responsiblePerson,
                    isReviewed = 1,
                    date ="...",
                };
            }
            else
            {
                var responsiblePerson = await _db.Assessments.Where(e => e.RiskId == id && e.IsMitigated==true).Select(e => e.Review.User.FullName).FirstOrDefaultAsync();

                var assessments = await _db.Assessments.Where(e => e.RiskId == id && e.IsMitigated)
             .Select(e => new
             {
                 actionBy = responsiblePerson,
                 isReviewed = e.Review.ReviewStatus,
                 date = e.Review.CreatedAt,
             }).FirstOrDefaultAsync();
                return assessments != null ? assessments : new
                {
                    actionBy = responsiblePerson,
                    isReviewed = 0,
                    date = "...",
                };
            }
          
        }
    }
}
