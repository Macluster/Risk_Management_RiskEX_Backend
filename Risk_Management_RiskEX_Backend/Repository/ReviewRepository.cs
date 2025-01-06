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

            var responsiblePerson = await _db.Assessments.Where(e => e.RiskId == id).Select(e=>e.Review.User.FullName).FirstOrDefaultAsync();
         
            if (isPreReview)
            {

                var assessments = await _db.Assessments.Where(e => e.RiskId == id && !e.IsMitigated)
               .Select(e => new
               {
                   actionBy = responsiblePerson,
                   isReviewed = true,
                   date = e.Review.CreatedAt,
               }).FirstOrDefaultAsync();
                  return assessments != null ? assessments : new
                {
                    actionBy = responsiblePerson,
                    isReviewed = false,
                    date ="...",
                };
            }
            else
            {

                var assessments = await _db.Assessments.Where(e => e.RiskId == id && e.IsMitigated)
             .Select(e => new
             {
                 actionBy = responsiblePerson,
                 isReviewed = true,
                 date = e.Review.CreatedAt,
             }).FirstOrDefaultAsync();
                return assessments != null ? assessments : new
                {
                    actionBy = responsiblePerson,
                    isReviewed = false,
                    date = "...",
                };
            }
          
        }
    }
}
