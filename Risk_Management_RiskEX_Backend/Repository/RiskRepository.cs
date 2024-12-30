using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;


using Microsoft.EntityFrameworkCore.Storage;


namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskRepository : IRiskRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;



        public RiskRepository(ApplicationDBContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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




        public async Task<Risk> AddQualityRiskAsync(RiskDTO riskDto)
        {
            using IDbContextTransaction transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                // 1. First create the Review (since it's referenced by Assessment)
                var firstReview = riskDto.RiskAssessments[0].Review;
                var review = new Review
                {
                    Comments = firstReview.Comments,
                    ReviewStatus = firstReview.ReviewStatus
                };

                if (firstReview.UserId.HasValue)
                {
                    review.UserId = firstReview.UserId;
                    review.ExternalReviewerId = null;
                }
                else if (firstReview.ExternalReviewerId.HasValue)
                {
                    review.ExternalReviewerId = firstReview.ExternalReviewerId;
                    review.UserId = null;
                }

                _db.Reviews.Add(review);
                await _db.SaveChangesAsync();

                // 2. Create Risk with all properties from DTO
                var risk = new Risk
                {
                    RiskId = riskDto.RiskId,
                    RiskName = riskDto.RiskName,
                    Description = riskDto.Description,
                    RiskType = riskDto.RiskType,
                    Impact = riskDto.Impact,
                    Mitigation = riskDto.Mitigation,
                    Contingency = riskDto.Contingency,
                    OverallRiskRating = riskDto.OverallRiskRating,
                    ResponsibleUserId = riskDto.ResponsibleUserId,
                    PlannedActionDate = riskDto.PlannedActionDate,
                    DepartmentId = riskDto.DepartmentId,
                    ProjectId = riskDto.ProjectId,
                    ClosedDate = null,
                    RiskResponseId = null,
                    Remarks = null,
                    RiskStatus = RiskStatus.open,
                    RiskAssessments = new List<RiskAssessment>()
                };

                // 3. Add Assessments based on RiskType
                if ((int)riskDto.RiskType == 1 || riskDto.RiskType == RiskType.Quality)
                {
                    // For Quality risks - single assessment
                    risk.RiskAssessments.Add(new RiskAssessment
                    {
                        ReviewId = review.Id,
                        AssessmentBasisId = null,
                        Likelihood = riskDto.RiskAssessments[0].Likelihood,
                        Impact = riskDto.RiskAssessments[0].Impact,
                        RiskFactor = riskDto.RiskAssessments[0].RiskFactor,
                        IsMitigated = false
                    });
                }


                _db.Risks.Add(risk);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return risk;
            }
            catch (DbUpdateException dbEx)
            {
                await transaction.RollbackAsync();
                throw new Exception("Database update error: " + dbEx.Message, dbEx);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An unexpected error occurred while adding risk: " + ex.Message, ex);
            }
        }








        public async Task<Risk> AddSecurityOrPrivacyRiskAsync(RiskDTO riskDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // 1. Create single Review from the first assessment's review data
                    var firstReview = riskDto.RiskAssessments.FirstOrDefault()?.Review;
                    if (firstReview == null)
                    {
                        throw new ArgumentException("Review data is required.");
                    }

                    // Create single Review that will be shared across all assessments
                    Review review = new Review
                    {
                        Comments = firstReview.Comments,
                        ReviewStatus = firstReview.ReviewStatus,
                        UserId = firstReview.UserId,
                        ExternalReviewerId = firstReview.ExternalReviewerId
                    };

                    if (review.UserId.HasValue && review.ExternalReviewerId.HasValue)
                    {
                        throw new ArgumentException("Only one reviewer can be assigned (either userId or externalReviewerId).");
                    }

                    if (review.UserId.HasValue)
                    {
                        review.ExternalReviewerId = null;
                    }
                    else if (review.ExternalReviewerId.HasValue)
                    {
                        review.UserId = null;
                    }
                    else
                    {
                        throw new ArgumentException("Either userId or externalReviewerId must be provided.");
                    }

                    _db.Reviews.Add(review);
                    await _db.SaveChangesAsync();

                    // 2. Create Risk object
                    var risk = new Risk
                    {
                        RiskId = riskDto.RiskId,
                        RiskName = riskDto.RiskName,
                        Description = riskDto.Description,
                        RiskType = riskDto.RiskType,
                        Impact = riskDto.Impact,
                        Mitigation = riskDto.Mitigation,
                        Contingency = riskDto.Contingency,
                        OverallRiskRating = riskDto.OverallRiskRating,
                        ResponsibleUserId = riskDto.ResponsibleUserId,
                        PlannedActionDate = riskDto.PlannedActionDate,
                        DepartmentId = riskDto.DepartmentId,
                        ProjectId = riskDto.ProjectId,
                        RiskStatus = RiskStatus.open,
                        RiskAssessments = new List<RiskAssessment>()
                    };

                    _db.Risks.Add(risk);
                    await _db.SaveChangesAsync();

                    // 3. Create all RiskAssessments with the same Review
                    foreach (var assessmentDto in riskDto.RiskAssessments)
                    {
                        var riskAssessment = new RiskAssessment
                        {
                            RiskId = risk.Id,
                            ReviewId = review.Id,  // Use the same review ID for all assessments
                            AssessmentBasisId = assessmentDto.AssessmentBasisId,
                            Likelihood = assessmentDto.Likelihood,
                            Impact = assessmentDto.Impact,
                            RiskFactor = assessmentDto.RiskFactor,
                            IsMitigated = assessmentDto.IsMitigated
                        };

                        risk.RiskAssessments.Add(riskAssessment);
                    }

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return risk;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Error adding risk: {ex.Message}", ex);
                }
            }
        }


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
                PlannedActionDate = r.PlannedActionDate != null ? r.PlannedActionDate.ToString() : "No planned action date set.",
                r.Remarks,


                RiskStatus = r.RiskStatus.ToString(),
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

        public async Task<Object> GetMitigationStatusOfARisk(int id)
        {
            var assessments = await _db.Assessments.Where(e => e.RiskId == id).ToListAsync();
            var risks = _db.Risks.Where(e => e.Id == id).Select(s => s.ResponsibleUser).FirstOrDefault();




            foreach (var assessment in assessments)
            {
                if (assessment.IsMitigated)
                {
                    return new
                    {

                        actionBy = risks != null ? risks.FullName : null,
                        isMitigated = true,


                    };
                }

            }
            return null;
        }


    }


}
       


      
      


    


    


