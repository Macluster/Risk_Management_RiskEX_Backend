using System.Collections;
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
            .Select(r => new RiskResponseDTO
            {
                Id = r.Id,
                RiskId = r.RiskId,
                RiskName = r.RiskName,
                Description = r.Description,
                Impact = r.Impact,
                Mitigation = r.Mitigation,
                Contingency= r.Contingency!=null? r.Contingency:null,
                OverallRiskRating=   r.OverallRiskRating,
                PlannedActionDate = r.PlannedActionDate != null ? r.PlannedActionDate.ToString() : "No planned action date set.",
                Remarks= r.Remarks!=null?r.Remarks:null,


                RiskStatus = r.RiskStatus.ToString(),
                RiskType= r.RiskType.ToString(),


                RiskAssessments =  r.RiskAssessments.Select(ra => new RiskAssessmentResponseDTO
                {
                    Id=ra.Id,

                    Review = ra.Review!=null? new 
                    {
                        Id= ra.Review.Id,
                        ReviewStatus = ra.Review.ReviewStatus.ToString(),
                        Comments=  ra.Review.Comments,
                        ReviewerName = ra.Review.ExternalReviewer == null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                    }:null ,
                    AssessmentBasis = ra.AssessmentBasis != null ? new AssessmentBasisResponseDTO { Id= ra.AssessmentBasis.Id, Basis= ra.AssessmentBasis.Basis } : null,
                    RiskFactor=ra.RiskFactor,

                    IsMitigated = ra.IsMitigated,

                    ImpactMatix = new { Impact = ra.MatrixImpact.AssessmentFactor, Value = ra.MatrixImpact.Impact },
                    LikelihoodMatrix= new{ LikeliHood = ra.MatrixLikelihood.AssessmentFactor, Value = ra.MatrixLikelihood.Likelihood },


                }).ToList(),
                ResponsibleUser = r.ResponsibleUser!=null?  new UserResponseDTO {Id= r.ResponsibleUser.Id, FullName= r.ResponsibleUser.FullName }:null ,
                Department =  new  DepartmentDTO{ Id= r.Department.Id, Name= r.Department.DepartmentName },
                Project = r.Project!=null?  new ProjectResponseDTO {  Id=r.Project.Id,  ProjectName=r.Project.Name }:null,
                CreatedBy= r.CreatedBy.FullName,
                CreatedAt= r.CreatedAt,
                UpdatedBy = r.UpdatedBy!=null? r.UpdatedBy.FullName:null,
                
                UpdatedAt= r.UpdatedAt
            })
            .FirstOrDefaultAsync();


            return risk;
        }

        public async Task<Object> GetMitigationStatusOfARisk(int id)
        {
            var responsibleUser = await _db.Risks
                 .Where(e => e.Id == id)
                 .Select(s => s.ResponsibleUser)
                 .FirstOrDefaultAsync();

           
            var isMitigated = await _db.Assessments
                .AnyAsync(e => e.RiskId == id && e.IsMitigated);

           
            if (isMitigated)
            {
                return new
                {
                    actionBy = responsibleUser?.FullName,
                    isMitigated = true
                };
            }

           
            return null;
        }

    public async Task<ICollection<int>> GetOverallRiskRating()
    {
         return await _db.Set<Risk>()
        .Select(r => r.OverallRiskRating)
        .ToListAsync();
    }

    public async Task<object> GetOverallRiskRating(int id)
    {
      return await _db.Set<Risk>()
     .Where(r => r.Id == id)
     .Select(r => (int?)r.OverallRiskRating)
     .FirstOrDefaultAsync();

    }

        //public async Task<object> GetRiskByAssigneeId(int id)
        //{
        //    var result = await _db.Risks.Where(e => e.ResponsibleUserId == id).ToListAsync();

        //    //var Risks=_mapper.Map<>(result);

            
        //}
    }


}
       


      
      



