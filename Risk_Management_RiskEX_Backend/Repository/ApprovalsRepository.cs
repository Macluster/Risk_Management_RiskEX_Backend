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
        public ApprovalsRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Review>> GetReviewByRiskIdAsync(int riskId)
        {
            var risk = await _db.Risks
                .Include(r => r.RiskAssessments)
                .ThenInclude(ra => ra.Review)
                .FirstOrDefaultAsync(r => r.Id == riskId);

            return risk?.RiskAssessments?.Select(ra => ra.Review).ToList();
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
                    RiskType = ra.Risk.RiskType,  // Keep enum as it is
                    PlannedActionDate = ra.Risk.PlannedActionDate,
                    OverallRiskRating = ra.Risk.OverallRiskRatingAfter ?? ra.Risk.OverallRiskRatingBefore,
                    RiskStatus = ra.Risk.RiskStatus,  // Keep enum as it is
                    ReviewerName = r.UserId.HasValue ? r.User.FullName : r.ExternalReviewer.FullName,
                    ReviewerDepartment = r.UserId.HasValue ? r.User.Department.DepartmentName : r.ExternalReviewer.Department.DepartmentName
                }))
                 .GroupBy(r => r.Id) // Group by the risk Id to ensure distinct records
                .Select(g => g.First()) // Select the first record from each group
                .ToListAsync();

            // After fetching the data, convert enums to strings in memory
            var riskDetails = risks.Select(r => new RiskDetailsDTO
            {
                Id = r.Id,
                RiskId = r.RiskId,
                RiskName = r.RiskName,
                RiskDepartment = r.RiskDepartment,
                Description = r.Description,
                RiskType = Enum.GetName(typeof(RiskType), r.RiskType),  // Convert enum to string here
                PlannedActionDate = r.PlannedActionDate,
                OverallRiskRating = (int)r.OverallRiskRating,
                RiskStatus = Enum.GetName(typeof(RiskStatus), r.RiskStatus),  // Convert enum to string here
                ReviewerName = r.ReviewerName,
                ReviewerDepartment = r.ReviewerDepartment
            }).ToList();

            return riskDetails;
        }


        //public async Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId)
        //{
        //    if (!userId.HasValue)
        //    {
        //        Console.WriteLine("No userId provided.");
        //        return new List<ApprovalDTO>();
        //    }

        //    // Query the reviews by userId and specific review status values
        //    var reviews = await _db.Reviews
        //        .Where(r => r.UserId == userId &&
        //                    (r.ReviewStatus == ReviewStatus.ReviewPending || r.ReviewStatus == ReviewStatus.ApprovalPending))
        //        .Include(r => r.RiskAssessments)
        //        .ThenInclude(ra => ra.Risk)
        //        .ThenInclude(risk => risk.Department)

        //        .ToListAsync();

        //    Console.WriteLine($"Found {reviews.Count} reviews for userId {userId.Value}.");

        //    // Check if reviews were found for this user
        //    if (reviews == null || reviews.Count == 0)
        //    {
        //        Console.WriteLine("No reviews found for this user.");
        //        return new List<ApprovalDTO>();
        //    }

        //    // Get the unique risks associated with the reviews (where risk is not null)
        //    var risks = reviews
        //        .SelectMany(r => r.RiskAssessments)
        //        .Where(ra => ra.Risk != null)
        //        .Select(ra => ra.Risk)
        //        .Distinct()
        //        .ToList();

        //    Console.WriteLine($"Found {risks.Count} unique risks.");

        //    // Create a list of ApprovalDTOs from the unique risks
        //    var approvalDTOs = risks.Select(risk => new ApprovalDTO
        //    {
        //        Id = risk.Id, 
        //        RiskId = risk.RiskId,
        //        RiskName = risk.RiskName,
        //        Description = risk.Description,

        //        RiskType = Enum.GetName(typeof(RiskType), risk.RiskType) ?? "Unknown",
        //        OverallRiskRating = risk.OverallRiskRatingAfter ?? risk.OverallRiskRatingBefore,

        //        //RiskType = risk.RiskType,
        //        //OverallRiskRating = risk.OverallRiskRatingBefore,

        //        PlannedActionDate = risk.PlannedActionDate,
        //        RiskStatus = Enum.GetName(typeof(RiskStatus), risk.RiskStatus) ?? "Unknown",
        //    }).ToList();

        //    return approvalDTOs;
        //}

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
                .ThenInclude(risk => risk.Department) // Ensure Department is included
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
                DepartmentName = risk.Department?.DepartmentName ?? "No Department" // Include DepartmentName
            }).ToList();

            return approvalDTOs;
        }



        public async Task<bool> UpdateReviewStatusAsync(int riskId, string approvalStatus)
        {
            var review = await GetReviewByRiskIdAsync(riskId);
            Review tempReview = null; 

            if (review == null)
            {
                return false; 
            }
            if (review.Count() == 1)
            {
                switch (approvalStatus.ToLower())
                {
                    case "approved":
                        if (review.ElementAt(0).ReviewStatus == ReviewStatus.ReviewPending)
                        {
                            review.ElementAt(0).ReviewStatus = ReviewStatus.ReviewCompleted;
                        }
                        else if (review.ElementAt(0).ReviewStatus == ReviewStatus.ApprovalPending)
                        {
                            review.ElementAt(0).ReviewStatus = ReviewStatus.ApprovalCompleted;
                        }
                        break;

                    case "rejected":
                        review.ElementAt(0).ReviewStatus = ReviewStatus.Rejected;
                        break;

                    default:
                        return false;
                }
                tempReview = review.ElementAt(0);
            }
            else
            {
                switch (approvalStatus.ToLower())
                {
                    case "approved":
                        if (review.ElementAt(1).ReviewStatus == ReviewStatus.ReviewPending)
                        {
                            review.ElementAt(1).ReviewStatus = ReviewStatus.ReviewCompleted;
                        }
                        else if (review.ElementAt(1).ReviewStatus == ReviewStatus.ApprovalPending)
                        {
                            review.ElementAt(1).ReviewStatus = ReviewStatus.ApprovalCompleted;
                        }
                        break;

                    case "rejected":
                        review.ElementAt(1).ReviewStatus = ReviewStatus.Rejected;
                        break;

                    default:
                        return false;
                }
                tempReview = review.ElementAt(1);

            }
            //switch (approvalStatus.ToLower())
            //{
            //    case "approved":
            //        if (review.ReviewStatus == ReviewStatus.ReviewPending)
            //        {
            //            review.ReviewStatus = ReviewStatus.ReviewCompleted;
            //        }
            //        else if (review.ReviewStatus == ReviewStatus.ApprovalPending)
            //        {
            //            review.ReviewStatus = ReviewStatus.ApprovalCompleted;
            //        }
            //        break;

            //    case "rejected":
            //        review.ReviewStatus = ReviewStatus.Rejected;
            //        break;

            //    default:
            //        return false; 
            //}

            _db.Reviews.Update(tempReview);
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateReviewCommentByRiskIdAsync(int riskId, string comments)
        {
            var review = await GetReviewByRiskIdAsync(riskId);
            if (review == null)
                return false;

            if (review.Count() == 1)
            {
                review.ElementAt(0).Comments = comments;
            }
            else if(review.Count() == 2)
            {
                review.ElementAt(1).Comments = comments;
            }

            //    var review = await _db.Set<RiskAssessment>()
            //                           .Where(ra => ra.RiskId == riskId)
            //                           .Select(ra => ra.Review)
            //                           .FirstOrDefaultAsync();

            //if (review == null)
            //    return false; 

            
            //review.Comments = comments;

            
            await _db.SaveChangesAsync();

            return true; 
        }

        


    }

}
