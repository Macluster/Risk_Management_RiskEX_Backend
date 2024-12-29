using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskRepository : IRiskRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public RiskRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
        //public async Task<IEnumerable<Risk>> GetRisksByReviewerIdAsync(int userId)
        //{



        //if (userId.HasValue)
        //{
        //    throw new ArgumentException("Either userId or externalReviewerId must be null, not both.");
        //}

        //if (!userId.HasValue)
        //{
        //    throw new ArgumentException("Either userId or externalReviewerId must be provided.");
        //}


        //IQueryable<Review> reviewsQuery = _db.Reviews.Include(r => r.RiskAssessments).ThenInclude(ra => ra.Risk);

        //if (userId.HasValue)
        //{
        //    reviewsQuery = reviewsQuery.Where(r => r.UserId == userId.Value);
        //}
        //else
        //{
        //    reviewsQuery = reviewsQuery.Where(r => r.ExternalReviewerId == externalReviewerId.Value);
        //}

        //var reviews = await reviewsQuery.ToListAsync();

        //if (reviews == null || reviews.Count == 0)
        //{
        //    return new List<Risk>(); 
        //}

        //// Get all unique risks from the assessments
        //var risks = reviews
        //    .SelectMany(r => r.RiskAssessments)
        //    .Select(ra => ra.Risk)
        //    .Distinct()
        //    .ToList();

        //return risks;
        //}


        public async Task<Object> GetRiskById(int id)
        {
            var risk = await _db.Risks
            .Where(x => x.Id == id)
            .Select(r => new
            {
                r.Id,
                r.RiskId,
                r.RiskName,
                r.Description,
                r.Impact,
                r.Mitigation,
                r.Contingency,
                r.OverallRiskRating,
                r.PlannedActionDate,
                r.Remarks,


                RiskStatus = r.RiskStatus.Value.ToString(),
                r.RiskType,

                RiskAssessments = r.RiskAssessments != null ? r.RiskAssessments.Select(ra => new
                {
                    ra.Id,

                    Review = ra.Review != null ? new
                    {
                        ra.Review.Id,
                        ReviewStatus = ra.Review.ReviewStatus.ToString(),
                        ra.Review.Comments,
                        reviewerName = ra.Review.ExternalReviewer == null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                    } : null,
                    AssessmentBasis = ra.AssessmentBasis != null ? new { ra.AssessmentBasis.Id, ra.AssessmentBasis.Basis } : null,

                    ra.IsMitigated,

                    ImpactMatix = new { Impact = ra.MatrixImpact.AssessmentFactor, Value = ra.MatrixImpact.Impact },
                    LikeliHoodMatix = new { LikeliHood = ra.MatrixLikelihood.AssessmentFactor, Value = ra.MatrixLikelihood.Likelihood },

                }).ToList() : null,
                ResponsibleUser = r.ResponsibleUser != null ? new { r.ResponsibleUser.Id, r.ResponsibleUser.FullName } : null,
                Department = r.Department != null ? new { r.Department.Id, r.Department.DepartmentName } : null,
                Project = r.Project != null ? new { r.Project.Id, r.Project.Name } : null,
                CreatedBy = r.CreatedBy != null ? new
                {
                    r.CreatedBy.Id,
                    r.CreatedBy.FullName
                } : null
            })
            .FirstOrDefaultAsync();


            return risk;
        }



        public async Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId)
        {
            if (!userId.HasValue)
            {
                Console.WriteLine("No userId provided.");
                return new List<ApprovalDTO>();
            }

            var reviews = await _db.Reviews
                .Where(r => r.UserId == userId.Value)
                .Include(r => r.RiskAssessments)
                .ThenInclude(ra => ra.Risk)
                .ToListAsync();

            Console.WriteLine($"Found {reviews.Count} reviews for userId {userId.Value}.");

            if (reviews == null || reviews.Count == 0)
            {
                Console.WriteLine("No reviews found for this user.");
                return new List<ApprovalDTO>();
            }

            var risks = reviews
                .SelectMany(r => r.RiskAssessments)
                .Where(ra => ra.Risk != null) // Ensure Risk is not null
                .Select(ra => ra.Risk)
                .Distinct()
                .ToList();

            Console.WriteLine($"Found {risks.Count} unique risks.");

            var approvalDTOs = risks.Select(risk => new ApprovalDTO
            {
                RiskId = risk.RiskId,
                RiskName = risk.RiskName,
                Description = risk.Description,
                RiskType = risk.RiskType,
                OverallRiskRating = risk.OverallRiskRating,
                PlannedActionDate = risk.PlannedActionDate,
                RiskStatus = risk.RiskStatus
            }).ToList();

            return approvalDTOs;


        }



    }
}
