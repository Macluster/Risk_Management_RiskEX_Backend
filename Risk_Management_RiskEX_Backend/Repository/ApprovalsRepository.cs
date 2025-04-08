using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class ApprovalsRepository : IApprovalRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IRiskRepository _riskRepository;
        public ApprovalsRepository(ApplicationDBContext db, IRiskRepository riskRepository)
        {
            _db = db;
            _riskRepository = riskRepository;
        }

        public async Task<IEnumerable<Review>> GetReviewByRiskIdAsync(int riskId)
        {
            var risk = await _db.Risks
                .Include(r => r.RiskAssessments)
                .ThenInclude(ra => ra.Review)
                .FirstOrDefaultAsync(r => r.Id == riskId);

            if (risk == null || risk.RiskAssessments == null)
            {
                return Enumerable.Empty<Review>();
            }

            // Select distinct reviews based on Review.Id
            var distinctReviews = risk.RiskAssessments
                 .Where(ra => ra.Review != null)
                 .Select(ra => ra.Review)
                 .GroupBy(review => review.Id)
                 .Select(group => group.First())
                 .OrderBy(review => review.CreatedAt) // Replace with the appropriate field
                 .ToList();


            return distinctReviews;
        }

        public async Task<IEnumerable<RiskDetailsDTO>> GetRiskDetailsToReviewAsync()
        {
            var risks = await _db.Reviews
                .Include(r => r.User)
                    .ThenInclude(u => u.Department)
                .Include(r => r.RiskAssessments)
                    .ThenInclude(ra => ra.Risk)
                        .ThenInclude(risk => risk.Department)
                .Where(r => r.ReviewStatus == ReviewStatus.ReviewPending || r.ReviewStatus == ReviewStatus.ApprovalPending)
                .SelectMany(r => r.RiskAssessments.Select(ra => new
                {
                    Id =ra.Risk.Id,
                    RiskId = ra.Risk.RiskId,
                    RiskName = ra.Risk.RiskName,
                    RiskDepartment = ra.Risk.Department.DepartmentName,
                    Description = ra.Risk.Description,
                    RiskType = ra.Risk.RiskType, 
                    PlannedActionDate = ra.Risk.PlannedActionDate,
                    OverallRiskRating = ra.Risk.OverallRiskRatingAfter ?? ra.Risk.OverallRiskRatingBefore,
                    RiskStatus = ra.Risk.RiskStatus, 
                    ReviewerName = r.UserId.HasValue ? r.User.FullName : r.ExternalReviewer.FullName,
                    ReviewerDepartment = r.UserId.HasValue ? r.User.Department.DepartmentName : r.ExternalReviewer.Department.DepartmentName
                }))
                 .GroupBy(r => r.Id) 
                .Select(g => g.First()) 
                .ToListAsync();

            // After fetching the data, convert enums to strings in memory
            var riskDetails = risks.Select(r => new RiskDetailsDTO
            {
                Id = r.Id,
                RiskId = r.RiskId,
                RiskName = r.RiskName,
                RiskDepartment = r.RiskDepartment,
                Description = r.Description,
                RiskType = Enum.GetName(typeof(RiskType), r.RiskType),  
                PlannedActionDate = r.PlannedActionDate,
                OverallRiskRating = (int)r.OverallRiskRating,
                RiskStatus = Enum.GetName(typeof(RiskStatus), r.RiskStatus), 
                ReviewerName = r.ReviewerName,
                ReviewerDepartment = r.ReviewerDepartment
            }).ToList();

            return riskDetails;
        }



        public async Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId)
        {
            if (!userId.HasValue)
            {
                Console.WriteLine("No userId provided.");
                return new List<ApprovalDTO>();
            }

            // Query the reviews by userId and specific review status values
            var reviews = await _db.Reviews
                .Where(r => r.UserId == userId &&
                            (r.ReviewStatus == ReviewStatus.ReviewPending || r.ReviewStatus == ReviewStatus.ApprovalPending))
                .Include(r => r.RiskAssessments)
                .ThenInclude(ra => ra.Risk)
                .ThenInclude(risk => risk.Department) 
                .ToListAsync();

            Console.WriteLine($"Found {reviews.Count} reviews for userId {userId.Value}.");

            // Check if reviews were found for this user
            if (reviews == null || reviews.Count == 0)
            {
                Console.WriteLine("No reviews found for this user.");
                return new List<ApprovalDTO>();
            }

            // Get the unique risks associated with the reviews (where risk is not null)
            var risks = reviews
                .SelectMany(r => r.RiskAssessments)
                .Where(ra => ra.Risk != null)
                .Select(ra => ra.Risk)
                .Distinct()
                .ToList();

            Console.WriteLine($"Found {risks.Count} unique risks.");

            // Create a list of ApprovalDTOs from the unique risks
            var approvalDTOs = risks.Select(risk => new ApprovalDTO
            {
                Id = risk.Id,
                RiskId = risk.RiskId,
                RiskName = risk.RiskName,
                Description = risk.Description,
                RiskType = Enum.GetName(typeof(RiskType), risk.RiskType) ?? "Unknown",
                OverallRiskRating = risk.OverallRiskRatingAfter ?? risk.OverallRiskRatingBefore,
                PlannedActionDate = risk.PlannedActionDate,
                RiskStatus = Enum.GetName(typeof(RiskStatus), risk.RiskStatus) ?? "Unknown",
                DepartmentName = risk.Department?.DepartmentName ?? "No Department"
            }).ToList();

            return approvalDTOs;

            
        }

        public async Task<Review> GetReviewBasedPostOrPre(int riskId,bool isMitigated)
        {
           
            var risk = await _db.Risks
            .Include(r => r.RiskAssessments.Where(ra => ra.IsMitigated==isMitigated)) 
            .ThenInclude(ra => ra.Review) 
            .FirstOrDefaultAsync(r => r.Id == riskId);


            return risk?.RiskAssessments?.Select(ra => ra.Review).FirstOrDefault();
            
        }

        public async Task<bool> UpdateReviewStatusAsync(int riskId, string approvalStatus)
        {
        
            dynamic mitigationStatus = await _riskRepository.GetMitigationStatusOfARisk(riskId);

          


            var review = await GetReviewBasedPostOrPre(riskId, mitigationStatus.isMitigated);


            if (review == null)
            {
                return false; 
            }
          
                switch (approvalStatus.ToLower())
                {
                    case "approved":
                        if (review.ReviewStatus == ReviewStatus.ReviewPending)
                        {
                            review.ReviewStatus = ReviewStatus.ReviewCompleted;
                        }
                        else if (review.ReviewStatus == ReviewStatus.ApprovalPending)
                        {
                            review.ReviewStatus = ReviewStatus.ApprovalCompleted;
                        }
                        break;

                    case "rejected":
                        review.ReviewStatus = ReviewStatus.Rejected;
                        var risk = await _db.Risks.FirstOrDefaultAsync(e => e.Id == riskId);
                        risk.RiskStatus=RiskStatus.open;
                       _db.Risks.Update(risk);

                         break;

                    default:
                        return false;
                }
              

            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateReviewCommentByRiskIdAsync(int riskId, string comments)
        {
            var review = await GetReviewByRiskIdAsync(riskId);
            if (review == null)
                return false;
            var reviewList = review.ToList();
            if (reviewList.Count() == 1)
            {
                reviewList[0].Comments = comments;
            }
            else if(reviewList.Count() == 2)
            {
                reviewList[1].Comments = comments;
            }
       
            await _db.SaveChangesAsync();

            return true; 
        }

        // New repository methods for the ApprovalRepository class
        public async Task<bool> UpdateSpecificReviewStatusAsync(int reviewId, string approvalStatus)
        {
         

            var review = await _db.Reviews
                .Include(r => r.RiskAssessments)
                .ThenInclude(ra => ra.Risk)
                .FirstOrDefaultAsync(r => r.Id == reviewId);



            if (review == null)
            {
                return false;
            }

            switch (approvalStatus.ToLower())
            {
                case "approved":
                    if (review.ReviewStatus == ReviewStatus.ReviewPending)
                    {
                        review.ReviewStatus = ReviewStatus.ReviewCompleted;
                    }
                    else if (review.ReviewStatus == ReviewStatus.ApprovalPending)
                    {
                        review.ReviewStatus = ReviewStatus.ApprovalCompleted;
                    }
                    break;

                case "rejected":
                    review.ReviewStatus = ReviewStatus.Rejected;

                    // Update associated risk status to "open"
                    var risk = review.RiskAssessments
                        .Select(ra => ra.Risk)
                        .FirstOrDefault();

                    if (risk != null)
                    {
                        risk.RiskStatus = RiskStatus.open;
                        _db.Risks.Update(risk);
                    }

                    break;

                default:
                    return false;
            }

            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateSpecificReviewCommentAsync(int reviewId, string comment)
        {
            var review = await _db.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            review.Comments = comment;
            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();
            return true;
        }

        // Updated method to handle risk status-based review selection
        //public async Task<Review> GetReviewBasedPostOrPre(int riskId, bool isMitigated)
        //{
        //    var risk = await _db.Risks
        //        .Include(r => r.RiskAssessments)
        //            .ThenInclude(ra => ra.Review)
        //        .FirstOrDefaultAsync(r => r.Id == riskId);

        //    if (risk == null || risk.RiskAssessments == null || !risk.RiskAssessments.Any())
        //    {
        //        return null;
        //    }

        //    // Sort assessments by ID to ensure we have them in creation order
        //    var sortedAssessments = risk.RiskAssessments.OrderBy(ra => ra.Id).ToList();

        //    if (risk.RiskStatus == RiskStatus.open && sortedAssessments.Count > 1)
        //    {
        //        // For open risks with multiple assessments, get the first assessment's review
        //        return sortedAssessments.First().Review;
        //    }
        //    else
        //    {
        //        // For closed risks or risks with only one assessment, get the latest assessment's review
        //        return sortedAssessments.Last().Review;
        //    }
        //}


    }

}
