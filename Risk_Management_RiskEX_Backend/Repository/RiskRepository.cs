using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography.X509Certificates;
using System.Security.Claims;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class RiskRepository : IRiskRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        private readonly IRiskMongoService _riskMongoService;  

       public RiskRepository(ApplicationDBContext db, IMapper mapper, IReviewRepository reviewRepository,IRiskMongoService riskMongoService)
        {
            _db = db;
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _riskMongoService=riskMongoService;
        }
        public async Task<ICollection<Risk>> GetRisksByType(RiskType riskType)
        {
                return await _db.Risks
               .Where(r => r.RiskType == riskType)
               .ToListAsync();
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
                    OverallRiskRatingBefore = riskDto.OverallRiskRatingBefore,
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

               
              

                // Throw a user-friendly message
                throw new Exception("An unexpected error occurred while processing your request.Please ensure all mandatory fields are filled. If the issue persists, contact the administrator or Please try again later");
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
                        OverallRiskRatingBefore = riskDto.OverallRiskRatingBefore,
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
                Contingency = r.Contingency != null ? r.Contingency : null,
                OverallRiskRating = r.OverallRiskRatingAfter.HasValue ? r.OverallRiskRatingAfter.Value : r.OverallRiskRatingBefore,
                OveralRiskRatingBefore=r.OverallRiskRatingBefore,
                OverallRiskRatingAfter=r.OverallRiskRatingAfter.HasValue?r.OverallRiskRatingAfter.Value:0,          
                PlannedActionDate = r.PlannedActionDate != null ? r.PlannedActionDate.ToString() : "No planned action date set.",
                Remarks = r.Remarks != null ? r.Remarks : null,
                
                RiskResponse=r.RiskResponseData.Name,
                RiskStatus = r.RiskStatus.ToString(),
                RiskType = r.RiskType.ToString(),


                RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentResponseDTO
                {
                    Id = ra.Id,

                    Review = ra.Review != null ? new
                    {
                        Id = ra.Review.Id,
                        ReviewStatus = ra.Review.ReviewStatus.ToString(),
                        Comments = ra.Review.Comments,
                        ReviewerName = ra.Review.ExternalReviewer == null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,

                    } : null,
                    AssessmentBasis = ra.AssessmentBasis != null ? new AssessmentBasisResponseDTO { Id = ra.AssessmentBasis.Id, Basis = ra.AssessmentBasis.Basis } : null,
                    RiskFactor = ra.RiskFactor,

                    IsMitigated = ra.IsMitigated,

                    ImpactMatix = new { Impact = ra.MatrixImpact.AssessmentFactor, Value = ra.MatrixImpact.Impact },
                    LikelihoodMatrix = new { LikeliHood = ra.MatrixLikelihood.AssessmentFactor, Value = ra.MatrixLikelihood.Likelihood },


                }).ToList(),
                ResponsibleUser = r.ResponsibleUser != null ? new UserResponseDTO { Id = r.ResponsibleUser.Id, FullName = r.ResponsibleUser.FullName,Email=r.ResponsibleUser.Email } : null,
                Department = new DepartmentDTO { Id = r.Department.Id, Name = r.Department.DepartmentName },
                Project = r.Project != null ? new ProjectResponseDTO { Id = r.Project.Id, ProjectName = r.Project.Name } : null,
                ResidualRisk = r.ResidualRisk.ToString(),
                ResidualValue = r.ResidualValue,
                PercentageRedution = r.PercentageRedution,
                CreatedBy =  new UserResponseDTO {  Id= r.CreatedBy!=null? r.CreatedBy.Id:0,FullName = r.CreatedBy != null ? r.CreatedBy.FullName : " " ,Email= r.CreatedBy != null ? r.CreatedBy.Email:""   },
                CreatedAt = r.CreatedAt,
                UpdatedBy = new UserResponseDTO { Id = r.UpdatedBy != null ? r.UpdatedBy.Id : 0, FullName = r.UpdatedBy != null ? r.UpdatedBy.FullName : " ", Email = r.UpdatedBy != null ? r.UpdatedBy.Email : "" },

                UpdatedAt = r.UpdatedAt,
                ClosedDate=r.ClosedDate!=null? r.ClosedDate.ToString() : ""
            })
            .FirstOrDefaultAsync();

            return risk;
        }



        public async Task<Risk> EditQualityRiskAsync(int id, RiskDTO riskDto)
        {

            // Start a transaction to ensure atomicity 

            using IDbContextTransaction transaction = await _db.Database.BeginTransactionAsync();

            try

            {

                // 1. Find the existing Risk by primary key (Id) 

                var existingRisk = await _db.Risks

                    .Include(r => r.RiskAssessments)

                    .ThenInclude(ra => ra.Review)

                    .FirstOrDefaultAsync(r => r.Id == id);  // Use primary key 'Id' 



                if (existingRisk == null)

                {

                    throw new KeyNotFoundException($"Risk with ID {id} not found.");

                }



                // 2. Update the properties, including RiskId 

                existingRisk.RiskId = riskDto.RiskId;  // Update the front-end RiskId 

                existingRisk.RiskName = riskDto.RiskName;

                existingRisk.Description = riskDto.Description;

                existingRisk.RiskType = riskDto.RiskType;

                existingRisk.Impact = riskDto.Impact;

                existingRisk.Mitigation = riskDto.Mitigation;

                existingRisk.Contingency = riskDto.Contingency;

                existingRisk.OverallRiskRatingBefore = riskDto.OverallRiskRatingBefore;

                existingRisk.ResponsibleUserId = riskDto.ResponsibleUserId;

                existingRisk.PlannedActionDate = riskDto.PlannedActionDate;

                existingRisk.DepartmentId = riskDto.DepartmentId;

                existingRisk.ProjectId = riskDto.ProjectId;
                // 3. Update Review (if present) 
                var firstReviewDto = riskDto.RiskAssessments[0].Review;
                var existingReview = existingRisk.RiskAssessments.FirstOrDefault()?.Review;
                if (existingReview == null)
                {
                    // Create a new review if it doesn't exist 
                    existingReview = new Review
                    {
                        Comments = firstReviewDto.Comments,
                        ReviewStatus = firstReviewDto.ReviewStatus
                    };
                    if (firstReviewDto.UserId.HasValue)
                    {
                        existingReview.UserId = firstReviewDto.UserId;
                        existingReview.ExternalReviewerId = null;
                    }
                    else if (firstReviewDto.ExternalReviewerId.HasValue)
                    {
                        existingReview.ExternalReviewerId = firstReviewDto.ExternalReviewerId;
                        existingReview.UserId = null;
                    }
                    _db.Reviews.Add(existingReview);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    // Update existing review 
                    existingReview.Comments = firstReviewDto.Comments;
                    existingReview.ReviewStatus = firstReviewDto.ReviewStatus;
                    if (firstReviewDto.UserId.HasValue)
                    {
                        existingReview.UserId = firstReviewDto.UserId;
                        existingReview.ExternalReviewerId = null;
                    }
                    else if (firstReviewDto.ExternalReviewerId.HasValue)
                    {
                        existingReview.ExternalReviewerId = firstReviewDto.ExternalReviewerId;
                        existingReview.UserId = null;
                    }
                    _db.Reviews.Update(existingReview);
                }
                // 4. Update RiskAssessments 
                foreach (var assessmentDto in riskDto.RiskAssessments)
                {
                    var existingAssessment = existingRisk.RiskAssessments
                        .FirstOrDefault(ra => ra.AssessmentBasisId == assessmentDto.AssessmentBasisId);
                    if (existingAssessment != null)
                    {
                        // Update existing assessment 
                        existingAssessment.Likelihood = assessmentDto.Likelihood;
                        existingAssessment.Impact = assessmentDto.Impact;
                        existingAssessment.RiskFactor = assessmentDto.RiskFactor;
                        existingAssessment.IsMitigated = assessmentDto.IsMitigated;
                        existingAssessment.ReviewId = existingReview.Id;
                    }
                    else
                    {
                        // Add new assessment if not found 
                        var newAssessment = new RiskAssessment
                        {
                            AssessmentBasisId = assessmentDto.AssessmentBasisId,
                            Likelihood = assessmentDto.Likelihood,
                            Impact = assessmentDto.Impact,
                            RiskFactor = assessmentDto.RiskFactor,
                            IsMitigated = assessmentDto.IsMitigated,
                            ReviewId = existingReview.Id
                        };
                        existingRisk.RiskAssessments.Add(newAssessment);
                    }
                }
                // Remove old assessments not in the new list 
                var assessmentIdsInDto = riskDto.RiskAssessments.Select(a => a.AssessmentBasisId).ToList();
                var assessmentsToRemove = existingRisk.RiskAssessments
                    .Where(ra => !assessmentIdsInDto.Contains(ra.AssessmentBasisId))
                    .ToList();
                _db.Assessments.RemoveRange(assessmentsToRemove);
               // 5. Save changes to the Risk 
                _db.Risks.Update(existingRisk);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return existingRisk;
            }
            catch (DbUpdateException dbEx)
            {
                await transaction.RollbackAsync();
                throw new Exception("Database update error: " + dbEx.Message, dbEx);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An unexpected error occurred while updating the risk: " + ex.Message, ex);
            }
        }



        public async Task<Risk> EditSecurityOrPrivacyRiskAsync(int id, RiskDTO riskDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // 1. Retrieve the existing Security Risk by primary key (Id) 
                    var existingRisk = await _db.Risks
                        .Include(r => r.RiskAssessments)
                        .ThenInclude(ra => ra.Review)  // Ensure Review is included 
                        .FirstOrDefaultAsync(r => r.Id == id);
                    if (existingRisk == null)
                    {
                        throw new KeyNotFoundException($"Risk with ID {id} not found.");
                    }
                    // 2. Update the properties, including RiskId 
                    existingRisk.RiskId = riskDto.RiskId;  // Update the front-end RiskId 
                    existingRisk.RiskName = riskDto.RiskName;
                    existingRisk.Description = riskDto.Description;
                    existingRisk.RiskType = riskDto.RiskType;
                    existingRisk.Impact = riskDto.Impact;
                    existingRisk.Mitigation = riskDto.Mitigation;
                    existingRisk.Contingency = riskDto.Contingency;
                    existingRisk.OverallRiskRatingBefore = riskDto.OverallRiskRatingBefore;
                    existingRisk.ResponsibleUserId = riskDto.ResponsibleUserId;
                    existingRisk.PlannedActionDate = riskDto.PlannedActionDate;
                    existingRisk.DepartmentId = riskDto.DepartmentId;
                    existingRisk.ProjectId = riskDto.ProjectId;
                    // 3. Update Review (if present) 
                    var firstReviewDto = riskDto.RiskAssessments[0].Review;
                    var existingReview = existingRisk.RiskAssessments.FirstOrDefault()?.Review;
                    if (existingReview == null)
                    {
                        // No existing review; create a new one 
                        existingReview = new Review
                        {
                            Comments = firstReviewDto.Comments,
                            ReviewStatus = firstReviewDto.ReviewStatus,
                            UserId = firstReviewDto.UserId,
                            ExternalReviewerId = firstReviewDto.ExternalReviewerId
                        };
                        _db.Reviews.Add(existingReview);
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        // Update existing review without creating a new reviewer 
                        existingReview.Comments = firstReviewDto.Comments;
                        existingReview.ReviewStatus = firstReviewDto.ReviewStatus;
                        if (firstReviewDto.UserId.HasValue)
                        {
                            existingReview.UserId = firstReviewDto.UserId;
                            existingReview.ExternalReviewerId = null;  // Clear ExternalReviewerId if a UserId is provided 
                        }
                        else if (firstReviewDto.ExternalReviewerId.HasValue)
                        {
                            existingReview.ExternalReviewerId = firstReviewDto.ExternalReviewerId;
                            existingReview.UserId = null;  // Clear UserId if an ExternalReviewerId is provided 
                        }
                        _db.Reviews.Update(existingReview); // Ensure we update the existing review 
                    }
                    // 4. Update the RiskAssessments or add new ones if necessary 
                    foreach (var assessmentDto in riskDto.RiskAssessments)
                    {
                        // Check if the assessment already exists using the 'AssessmentBasisId' 
                        var existingAssessment = existingRisk.RiskAssessments
                        .FirstOrDefault(ra => ra.AssessmentBasisId == assessmentDto.AssessmentBasisId);
                        if (existingAssessment != null)
                        {
                            // If the assessment already exists, update it 
                            existingAssessment.Likelihood = assessmentDto.Likelihood;
                            existingAssessment.Impact = assessmentDto.Impact;
                            existingAssessment.RiskFactor = assessmentDto.RiskFactor;
                            existingAssessment.IsMitigated = assessmentDto.IsMitigated;
                        }
                        else
                        {
                            // Add a new RiskAssessment if it does not exist 
                            var riskAssessment = new RiskAssessment
                            {
                                RiskId = existingRisk.Id,  // Use the primary key of the existing Risk 
                                ReviewId = existingReview.Id,  // Use the primary key of the Review 
                                AssessmentBasisId = assessmentDto.AssessmentBasisId,
                                Likelihood = assessmentDto.Likelihood,
                                Impact = assessmentDto.Impact,
                                RiskFactor = assessmentDto.RiskFactor,
                                IsMitigated = assessmentDto.IsMitigated
                            };
                            existingRisk.RiskAssessments.Add(riskAssessment);
                        }
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return existingRisk;
                }
                catch (Exception ex)

                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Error editing security risk: {ex.Message}", ex);
                }
            }
        }



        public async Task<Risk> UpdateQualityRiskAsync(int riskId, RiskUpdateDTO riskUpdateDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the existing Risk by ID 
                    var existingRisk = await _db.Risks.FirstOrDefaultAsync(r => r.Id == riskId);
                    if (existingRisk == null)
                    {
                        throw new KeyNotFoundException($"Risk with ID {riskId} not found.");
                    }

                    if (existingRisk.RiskStatus == RiskStatus.close)
                    {
                        throw new UnauthorizedAccessException($"This risk is already closed and cannot be updated.");
                    }

                    // Update Risk properties 


                    existingRisk.ClosedDate = riskUpdateDto.ClosedDate;
                        existingRisk.RiskStatus = RiskStatus.close; // Set status to closed 
                        existingRisk.RiskResponseId = riskUpdateDto.RiskResponseId;
                        existingRisk.OverallRiskRatingAfter=riskUpdateDto.OverallRiskRatingAfter;
                        existingRisk.PercentageRedution=riskUpdateDto.PercentageRedution;
                        existingRisk.ResidualRisk=riskUpdateDto.ResidualRisk;
                        existingRisk.ResidualValue=riskUpdateDto.ResidualValue;
                        existingRisk.Remarks=riskUpdateDto.Remarks;
                     
                    
                    
                    // Handle RiskAssessments and their Reviews 
                    foreach (var assessmentDto in riskUpdateDto.RiskAssessments)
                    {
                        // Create new RiskAssessment for the mitigated case 
                        var newAssessment = new RiskAssessment
                        {
                            RiskId = existingRisk.Id,
                            Likelihood = assessmentDto.Likelihood,
                            Impact = assessmentDto.Impact,
                            RiskFactor = assessmentDto.RiskFactor,
                            IsMitigated = true
                        };
                        // Add Review if provided 
                        if (assessmentDto.Review != null)
                        {
                            var newReview = new Review
                            {
                                Comments = assessmentDto.Review.Comments,
                                ReviewStatus = assessmentDto.Review.ReviewStatus
                            };
                            // Ensure only one of UserId or ExternalReviewerId is set 
                            if (assessmentDto.Review.UserId.HasValue)
                            {
                                newReview.UserId = assessmentDto.Review.UserId;
                                newReview.ExternalReviewerId = null;
                            }
                            else if (assessmentDto.Review.ExternalReviewerId.HasValue)
                            {
                                newReview.ExternalReviewerId = assessmentDto.Review.ExternalReviewerId;
                                newReview.UserId = null;
                            }
                            // Add the new Review to the database 
                            _db.Reviews.Add(newReview);
                            await _db.SaveChangesAsync(); // Save to generate ReviewId 
                            // Assign the ReviewId to the new assessment 
                            newAssessment.ReviewId = newReview.Id;
                        }
                        // Add the new assessment to the database 
                        _db.Assessments.Add(newAssessment);
                    }
                    // Save changes to the Risk entity 
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return existingRisk;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Error updating risk: {ex.Message}", ex);
                }

            }
        }



        public async Task<Risk> UpdateSecurityOrPrivacyRiskAsync(int riskId, RiskUpdateDTO riskUpdateDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the existing Risk by ID 
                    var existingRisk = await _db.Risks.FirstOrDefaultAsync(r => r.Id == riskId);
                    if (existingRisk == null)
                    {
                        throw new KeyNotFoundException($"Risk with ID {riskId} not found.");
                    }
                    // Update Risk properties 
                    existingRisk.ClosedDate = riskUpdateDto.ClosedDate;
                    existingRisk.RiskStatus = RiskStatus.close; // Set status to closed 
                    existingRisk.RiskResponseId = riskUpdateDto.RiskResponseId;
                    existingRisk.OverallRiskRatingAfter = riskUpdateDto.OverallRiskRatingAfter;
                    existingRisk.PercentageRedution = riskUpdateDto.PercentageRedution;
                    existingRisk.ResidualRisk = riskUpdateDto.ResidualRisk;
                    existingRisk.ResidualValue = riskUpdateDto.ResidualValue;
                    existingRisk.Remarks = riskUpdateDto.Remarks;
                    // Initialize a shared review if provided 
                    int sharedReviewId = 0;
                    if (riskUpdateDto.RiskAssessments.Any() && riskUpdateDto.RiskAssessments[0].Review != null)
                    {
                        var firstReviewDto = riskUpdateDto.RiskAssessments[0].Review;
                        var newReview = new Review
                        {
                            Comments = firstReviewDto.Comments,
                            ReviewStatus = firstReviewDto.ReviewStatus
                        };
                        // Ensure only one of UserId or ExternalReviewerId is set 
                        if (firstReviewDto.UserId.HasValue)
                        {
                            newReview.UserId = firstReviewDto.UserId;
                            newReview.ExternalReviewerId = null;
                        }
                        else if (firstReviewDto.ExternalReviewerId.HasValue)
                        {
                            newReview.ExternalReviewerId = firstReviewDto.ExternalReviewerId;
                            newReview.UserId = null;
                        }

                        // Add and save the new review 
                        _db.Reviews.Add(newReview);
                        await _db.SaveChangesAsync(); // Generate ReviewId 
                        sharedReviewId = newReview.Id;
                    }
                    // Handle RiskAssessments and assign shared ReviewId 
                    foreach (var assessmentDto in riskUpdateDto.RiskAssessments)
                    {
                        var newAssessment = new RiskAssessment
                        {
                            RiskId = existingRisk.Id,
                            Likelihood = assessmentDto.Likelihood,
                            Impact = assessmentDto.Impact,
                            RiskFactor = assessmentDto.RiskFactor,
                            AssessmentBasisId = assessmentDto.AssessmentBasisId,
                            IsMitigated = true,
                            ReviewId = sharedReviewId
                        };
                        // Add the new assessment to the database 
                        _db.Assessments.Add(newAssessment);
                    }
                    // Save changes to the Risk entity 
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return existingRisk;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Error updating risk: {ex.Message}", ex);
                }
            }
        }


        public async Task<Object> GetMitigationStatusOfARisk(int id)
        {
            var responsibleUser = await _db.Risks
            .Where(e => e.Id == id)
            .Select(s => s.ResponsibleUser)
            .FirstOrDefaultAsync();
            var isMitigated = await _db.Assessments
            .AnyAsync(e => e.RiskId == id && e.IsMitigated);


            var date=await _db.Assessments.Where(e=>e.RiskId==id&&e.IsMitigated) .FirstOrDefaultAsync();
            if (isMitigated)
            {
                return new
                {
                    actionBy = responsibleUser?.FullName,
                    date = date.CreatedAt,
                    isMitigated = true
                };
            }
            return new
            {
                actionBy = responsibleUser?.FullName,
                isMitigated = false
            };
        }

        public async Task<object> GetAllRiskAssigned()
        {
            var result = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open).Select(r => new GetAllRiskAssignedDTO
            {
                Id = r.Id,
                RiskId = r.RiskId,
                RiskName = r.RiskName,
                Description = r.Description,
                DepartmentName = r.Department.DepartmentName,
                ResponsibleUser=r.ResponsibleUser.FullName,
                RiskType = r.RiskType.ToString(),
                OverallRiskRating = r.OverallRiskRatingAfter.HasValue ? r.OverallRiskRatingAfter.Value : r.OverallRiskRatingBefore,
                PlannedActionDate = r.PlannedActionDate,
                RiskStatus = r.RiskStatus.ToString()

            }).ToListAsync();


            var Risks = _mapper.Map<List<GetAllRiskAssignedDTO>>(result);
            return Risks;
        }

        public async Task<object> GetRiskByAssigneeId(int id)
        {


            var result = await _db.Risks
      .Where(e => e.ResponsibleUserId == id)
      .Where(e => e.RiskStatus == RiskStatus.open)
      .Where(e => e.RiskAssessments.Any(ra => ra.Review != null && ra.Review.ReviewStatus == ReviewStatus.ReviewCompleted))
      .Include(e => e.RiskAssessments)
      .ThenInclude(e => e.Review)
      .Select(r => new RiskForApprovalDTO
      {
          Id = r.Id,
          RiskId = r.RiskId,
          RiskName = r.RiskName,
          Description = r.Description,
          RiskType = r.RiskType.ToString(),
          OverallRiskRating = r.OverallRiskRatingAfter.HasValue ? r.OverallRiskRatingAfter.Value : r.OverallRiskRatingBefore,
          PlannedActionDate = r.PlannedActionDate,
          RiskStatus = r.RiskStatus.ToString()
      })
      .ToListAsync();



            var Risks = _mapper.Map<List<RiskForApprovalDTO>>(result);
            return Risks;
        }

        public async Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCounts(int?id)
        {

            if (id == null)
            {
               var riskCategoryCounts = await _db.Set<Risk>().Where(e => e.RiskStatus == RiskStatus.open)
              .Select(r => new
              {
                  RiskType = r.RiskType.ToString(),
                  OverallRiskRating = r.OverallRiskRatingBefore,
                  RiskCategory = r.RiskType == RiskType.Quality
                      ? (r.OverallRiskRatingBefore <= 8 ? "Low" :
                         r.OverallRiskRatingBefore >= 9 && r.OverallRiskRatingBefore <= 32 ? "Moderate" :
                         r.OverallRiskRatingBefore >= 33 ? "Critical" : null)
                      : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
                      ? (r.OverallRiskRatingBefore <= 45 ? "Low" :
                         r.OverallRiskRatingBefore >= 46 && r.OverallRiskRatingBefore <= 69 ? "Moderate" :
                         r.OverallRiskRatingBefore >= 70 ? "Critical" :null)
                      :null
              })
               .Where(r => r.RiskCategory != null)  // Exclude any risk that doesn't fall into the 3 categories
               .Where(r => r.RiskCategory == "Low" || r.RiskCategory == "Moderate" || r.RiskCategory == "Critical")  // Only include Low, Moderate, or Critical categories

              .GroupBy(r => r.RiskCategory)
              .Select(g => new RiskCategoryCountDTO
              {
                  RiskCategory = g.Key,
                  Count = g.Count()
              })
              .ToListAsync();
                return riskCategoryCounts;

            }
            else
            {
                var riskCategoryCounts = await _db.Set<Risk>()
                     .Where(e => e.DepartmentId == id).Where(e => e.RiskStatus == RiskStatus.open)
                      .Select(r => new
                      {
                          RiskType = r.RiskType.ToString(),
                          OverallRiskRating = r.OverallRiskRatingBefore,
                          RiskCategory = r.RiskType == RiskType.Quality
                      ? (r.OverallRiskRatingBefore <= 8 ? "Low" :
                         r.OverallRiskRatingBefore >= 9 && r.OverallRiskRatingBefore <= 32 ? "Moderate" :
                         r.OverallRiskRatingBefore >= 33 ? "Critical" : "Uncategorized")
                      : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
                      ? (r.OverallRiskRatingBefore <= 45 ? "Low" :
                         r.OverallRiskRatingBefore >= 46 && r.OverallRiskRatingBefore <= 69 ? "Moderate" :
                         r.OverallRiskRatingBefore >= 70 ? "Critical" : "Uncategorized")
                      : "Uncategorized"
                      })

                      .Where(r => r.RiskCategory != null)  // Exclude any risk that doesn't fall into the 3 categories
                      .Where(r => r.RiskCategory == "Low" || r.RiskCategory == "Moderate" || r.RiskCategory == "Critical")  // Only include Low, Moderate, or Critical categories

              .GroupBy(r => r.RiskCategory)
              .Select(g => new RiskCategoryCountDTO
              {
                  RiskCategory = g.Key,
                  Count = g.Count()
              })
              .ToListAsync();
               return riskCategoryCounts;              
            }
           

        }


        //public async Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCountsByDepartments(List<int> departmentIds)
        //{
        //    var query = _db.Set<Risk>()
        //    .Where(r => !departmentIds.Any() || departmentIds.Contains(r.DepartmentId)).Where(e => e.RiskStatus == RiskStatus.open) // Filter by department IDs if provided 
        //    .Select(r => new
        //    {
        //        r.DepartmentId,
        //        r.RiskType,
        //        r.OverallRiskRatingBefore,
        //        RiskCategory = r.RiskType == RiskType.Quality
        //            ? (r.OverallRiskRatingBefore <= 8 ? "Low" :
        //               r.OverallRiskRatingBefore >= 9 && r.OverallRiskRatingBefore <= 32 ? "Moderate" :
        //               r.OverallRiskRatingBefore >= 33 ? "Critical" : null)
        //            : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
        //            ? (r.OverallRiskRatingBefore <= 45 ? "Low" :
        //               r.OverallRiskRatingBefore >= 46 && r.OverallRiskRatingBefore <= 69 ? "Moderate" :
        //               r.OverallRiskRatingBefore >= 70 ? "Critical" : null)
        //            : null
        //    })
        //        .GroupBy(r => new { r.DepartmentId, r.RiskCategory })
        //        .Select(g => new RiskCategoryCountDTO
        //        {

        //            RiskCategory = g.Key.RiskCategory,
        //            Count = g.Count()
        //        });


        //    List<RiskCategoryCountDTO> list = [
        //          new RiskCategoryCountDTO
        //    {

        //        RiskCategory ="Low",
        //        Count =0
        //    },
        //     new RiskCategoryCountDTO
        //    {

        //        RiskCategory = "Moderate",
        //        Count = 0
        //    },
        //     new RiskCategoryCountDTO
        //    {
        //        RiskCategory = "Critical",
        //        Count =0
        //    }
        //         ];





        //    foreach(RiskCategoryCountDTO q in query)
        //    {
        //        if(q.RiskCategory=="Low")
        //        {
        //            list.ElementAt(0).Count++;  
        //        }
        //        if (q.RiskCategory == "Moderate")
        //        {
        //            list.ElementAt(1).Count++;
        //        }
        //        if (q.RiskCategory == "Critical")
        //        {
        //            list.ElementAt(2).Count++;
        //        }



        //    }


        //    return list;
        //}







        public async Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCountsByDepartments(List<int> departmentIds, List<int> projects)
        {

            if (projects.Count != 0)
            {
                var query = await _db.Set<Risk>()
               .Where(r => !projects.Any() || projects.Contains(r.ProjectId.Value))
               .Where(r => r.RiskStatus == RiskStatus.open) // Filter by department IDs if provided
               .Select(r => new
               {
                   r.RiskType,
                   r.OverallRiskRatingBefore,
                   RiskCategory = r.RiskType == RiskType.Quality
                       ? (r.OverallRiskRatingBefore <= 8 ? "Low" :
                          r.OverallRiskRatingBefore >= 9 && r.OverallRiskRatingBefore <= 32 ? "Moderate" :
                          r.OverallRiskRatingBefore >= 33 ? "Critical" : null)
                       : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
                       ? (r.OverallRiskRatingBefore <= 45 ? "Low" :
                          r.OverallRiskRatingBefore >= 46 && r.OverallRiskRatingBefore <= 69 ? "Moderate" :
                          r.OverallRiskRatingBefore >= 70 ? "Critical" : null)
                       : null
               })
               .Where(r => r.RiskCategory != null) // Remove null categories
               .GroupBy(r => r.RiskCategory)
               .Select(g => new RiskCategoryCountDTO
               {
                   RiskCategory = g.Key,
                   Count = g.Count()
               })
               .ToListAsync(); // Materialize the query

                // Initialize default values for Low, Moderate, Critical
                var defaultCategories = new List<RiskCategoryCountDTO>
    {
        new RiskCategoryCountDTO { RiskCategory = "Low", Count = 0 },
        new RiskCategoryCountDTO { RiskCategory = "Moderate", Count = 0 },
        new RiskCategoryCountDTO { RiskCategory = "Critical", Count = 0 }
    };

                // Map the query results to the default list
                foreach (var result in query)
                {
                    var category = defaultCategories.FirstOrDefault(c => c.RiskCategory == result.RiskCategory);
                    if (category != null)
                    {
                        category.Count = result.Count;
                    }
                }

                return defaultCategories;

            }
            else
            {
                var query = await _db.Set<Risk>()
                  .Where(r => !departmentIds.Any() || departmentIds.Contains(r.DepartmentId))
                  .Where(r => r.RiskStatus == RiskStatus.open) // Filter by department IDs if provided
                  .Select(r => new
                  {
                      r.RiskType,
                      r.OverallRiskRatingBefore,
                      RiskCategory = r.RiskType == RiskType.Quality
                          ? (r.OverallRiskRatingBefore <= 8 ? "Low" :
                             r.OverallRiskRatingBefore >= 9 && r.OverallRiskRatingBefore <= 32 ? "Moderate" :
                             r.OverallRiskRatingBefore >= 33 ? "Critical" : null)
                          : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
                          ? (r.OverallRiskRatingBefore <= 45 ? "Low" :
                             r.OverallRiskRatingBefore >= 46 && r.OverallRiskRatingBefore <= 69 ? "Moderate" :
                             r.OverallRiskRatingBefore >= 70 ? "Critical" : null)
                          : null
                  })
                  .Where(r => r.RiskCategory != null) // Remove null categories
                  .GroupBy(r => r.RiskCategory)
                  .Select(g => new RiskCategoryCountDTO
                  {
                      RiskCategory = g.Key,
                      Count = g.Count()
                  })
                  .ToListAsync(); // Materialize the query

                // Initialize default values for Low, Moderate, Critical
                var defaultCategories = new List<RiskCategoryCountDTO>
    {
        new RiskCategoryCountDTO { RiskCategory = "Low", Count = 0 },
        new RiskCategoryCountDTO { RiskCategory = "Moderate", Count = 0 },
        new RiskCategoryCountDTO { RiskCategory = "Critical", Count = 0 }
    };

                // Map the query results to the default list
                foreach (var result in query)
                {
                    var category = defaultCategories.FirstOrDefault(c => c.RiskCategory == result.RiskCategory);
                    if (category != null)
                    {
                        category.Count = result.Count;
                    }
                }

                return defaultCategories;
            }

        }














        public async Task<Object> RiskApproachingDeadline(List<int> departmentIds, List<int> projects)
        {

            if (projects.Count() != 0)
            {



                var closestRisks = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open)
                .Where(e => projects.Contains(e.ProjectId.Value))
                .ToListAsync();
                var closestRisksSorted = closestRisks
                .OrderBy(r => Math.Abs((r.PlannedActionDate - DateTime.Now).Ticks))
                .Take(3)
                .ToList();
                var data = _mapper.Map<List<RiskMinimalInfoDTO>>(closestRisksSorted);
                return data;







            }
            else
            {
                if (departmentIds.Count() == 0)
                {
                    var closestRisks = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open)
                    .ToListAsync();
                    var closestRisksSorted = closestRisks
                    .OrderBy(r => Math.Abs((r.PlannedActionDate - DateTime.Now).Ticks))
                    .Take(3)
                    .ToList();
                    var data = _mapper.Map<List<RiskMinimalInfoDTO>>(closestRisksSorted);
                    return data;
                }
                else
                {
                    var closestRisks = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open)
                    .Where(e => departmentIds.Contains(e.DepartmentId))
                    .ToListAsync();
                    var closestRisksSorted = closestRisks
                    .OrderBy(r => Math.Abs((r.PlannedActionDate - DateTime.Now).Ticks))
                    .Take(3)
                    .ToList();
                    var data = _mapper.Map<List<RiskMinimalInfoDTO>>(closestRisksSorted);
                    return data;

                }
            }



        }

        public async Task<object> GetRiskWithHeighestOverallRationg(List<int> departmentIds, List<int> projectIds)
        {

            if (projectIds.Count() != 0)
            {
                var highestRatedRisk = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open).Where(e => projectIds.Contains(e.ProjectId.Value)).OrderByDescending(r => r.OverallRiskRatingBefore).Take(3).ToListAsync();
                var data = _mapper.Map<List<RiskMinimalInfoDTO>>(highestRatedRisk);
                return data;
            }
            else
            {

                if (departmentIds.Count() == 0)
                {
                    var highestRatedRisk = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open).OrderByDescending(r => r.OverallRiskRatingBefore).Take(3).ToListAsync();
                    var data = _mapper.Map<List<RiskMinimalInfoDTO>>(highestRatedRisk);
                    return data;
                }
                else
                {
                    var highestRatedRisk = await _db.Risks.Where(e => e.RiskStatus == RiskStatus.open).Where(e => departmentIds.Contains(e.DepartmentId)).OrderByDescending(r => r.OverallRiskRatingBefore).Take(3).ToListAsync();
                    var data = _mapper.Map<List<RiskMinimalInfoDTO>>(highestRatedRisk);
                    return data;
                }
            }

        }

        public async Task<ICollection<OpenRiskCountByTypeDTO>> GetOpenRiskCountByType(List<int> departmentIds, List<int> projectIds)
        {

            if (projectIds.Count() != 0)
            {

                var riskTypeCounts = await _db.Set<Risk>()
               .Where(e => projectIds.Contains(e.ProjectId.Value)).Where(e => e.RiskStatus == RiskStatus.open)
               .GroupBy(r => r.RiskType)
               .Select(g => new OpenRiskCountByTypeDTO
               {
                   RiskType = g.Key.ToString(),
                   RiskCount = g.Count()
               })
               .ToListAsync();
                return riskTypeCounts;
            }
            else
            {
                if (departmentIds.Count() == 0)
                {
                    var riskTypeCounts = await _db.Set<Risk>().Where(e => e.RiskStatus == RiskStatus.open)
                   .GroupBy(r => r.RiskType)
                   .Select(g => new OpenRiskCountByTypeDTO
                   {
                       RiskType = g.Key.ToString(),
                       RiskCount = g.Count()
                   })
                   .ToListAsync();
                    return riskTypeCounts;

                }
                else
                {

                    var riskTypeCounts = await _db.Set<Risk>()
                   .Where(e => departmentIds.Contains(e.DepartmentId)).Where(e => e.RiskStatus == RiskStatus.open)
                   .GroupBy(r => r.RiskType)
                   .Select(g => new OpenRiskCountByTypeDTO
                   {
                       RiskType = g.Key.ToString(),
                       RiskCount = g.Count()
                   })
                   .ToListAsync();
                    return riskTypeCounts;

                }
            }


        }



        public async Task<string> SetAndGetRiskIdAsync(int? departmentId, int? projectId)
        {
            if (!departmentId.HasValue && !projectId.HasValue)
            {
                throw new ArgumentException("Either DepartmentId or ProjectId is required.");
            }

            // Generate the base RiskId based on department or project codes
            string baseRiskId = await GenerateBaseRiskId(departmentId, projectId);

            // Query for the latest RiskId matching the baseRiskId
            var latestRisksQuery = _db.Risks.Where(r => r.RiskId.StartsWith(baseRiskId));

            // Fetch the latest risks ordered by RiskId
            var latestRisks = await latestRisksQuery
                .OrderByDescending(r => r.RiskId)
                .Take(1) // Only fetch the latest record
                .ToListAsync();

            // If no matching Risk is found, create a new RiskId starting with 001
            if (!latestRisks.Any())
            {
                return $"{baseRiskId}001";
            }

            // Extract and increment the numeric part from the latest matching RiskId
            int latestNumber = ExtractNumericPartFromRiskId(latestRisks.First().RiskId, baseRiskId) + 1;

            // Return the new RiskId with the incremented number, zero-padded to 3 digits
            return $"{baseRiskId}{latestNumber:D3}";
        }




        private async Task<string> GenerateBaseRiskId(int? departmentId, int? projectId)
        {
            if (departmentId.HasValue)
            {
                // Fetch the department details
                var department = await _db.Departments.FirstOrDefaultAsync(d => d.Id == departmentId.Value);
                if (department == null)
                {
                    throw new InvalidOperationException("Department not found.");
                }

                var departmentCode = department.DepartmentCode?.ToUpper()
                    ?? throw new InvalidOperationException("Department code is missing.");

                return $"RSK-{departmentCode}-";
            }
            else if (projectId.HasValue)
            {
                // Fetch the project details
                var project = await _db.Projects.FirstOrDefaultAsync(p => p.Id == projectId.Value);
                if (project == null)
                {
                    throw new InvalidOperationException("Project not found.");
                }

                var projectCode = project.ProjectCode?.ToUpper()
                    ?? throw new InvalidOperationException("Project code is missing.");

                return $"RSK-{projectCode}-";
            }

            throw new InvalidOperationException("Invalid input. Either departmentId or projectId is required.");
        }


        private static int ExtractNumericPartFromRiskId(string riskId, string baseRiskId)
        {
            // Ensure the RiskId is long enough to contain the baseRiskId
            if (riskId.Length <= baseRiskId.Length || !riskId.StartsWith(baseRiskId))
            {
                throw new InvalidOperationException($"RiskId '{riskId}' does not match the expected baseRiskId '{baseRiskId}'.");
            }

            // Extract the numeric part after the baseRiskId
            string numericPart = riskId.Substring(baseRiskId.Length);

            // Validate the numeric part
            if (!int.TryParse(numericPart, out int result))
            {
                throw new InvalidOperationException($"RiskId '{riskId}' contains an invalid numeric part: '{numericPart}'.");
            }

            return result;
        }



        public async Task<RiskDraftDTO> AddDraftQualityRiskAsync(RiskDraftDTO riskDraftDto)
        {
            if (riskDraftDto == null)
            {
                throw new ArgumentNullException(nameof(riskDraftDto), "Draft risk cannot be null.");
            }

            // Optional: Check if at least one field has value (custom logic if needed)
            if (string.IsNullOrWhiteSpace(riskDraftDto.RiskName))
               
            {
                throw new ArgumentException("Draft must have at least some data.");
            }

            try
            {
                await _riskMongoService.CreateAsync(riskDraftDto);
                return riskDraftDto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving draft: " + e.Message);
                throw new Exception("Failed to save draft. Please try again later.", e);
            }
        }





        public async Task<RiskDraftDTO> AddDraftSecurityOrPrivacyRiskAsync(RiskDraftDTO riskDraftDto)
        {
            if (riskDraftDto == null)
            {
                throw new ArgumentNullException(nameof(riskDraftDto), "Draft risk cannot be null.");
            }

            // Optional: Add validation logic here as needed
            if (string.IsNullOrWhiteSpace(riskDraftDto.RiskName) &&
                string.IsNullOrWhiteSpace(riskDraftDto.Description) &&
                riskDraftDto.RiskAssessments.Count == 0)
            {
                throw new ArgumentException("Draft must have at least some data.");
            }

            try
            {
                await _riskMongoService.CreateAsync(riskDraftDto);
                return riskDraftDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving security/privacy draft: " + ex.Message);
                throw new Exception("Failed to save draft. Please try again later.", ex);
            }
        }





        public async Task<List<Object>> GetAllDraftsAsync()
        {
            return await _riskMongoService.GetAllDraftsAsync();
        }


        public async Task<bool> DeleteDraftByIdAsync(string riskId)
        {
            return await _riskMongoService.DeleteDraftByIdAsync(riskId);
        }


        public async Task<List<Object>> GetAllDraftsByDepartmentIdAsync(int departmentId)
        {
            return await _riskMongoService.GetAllDraftsByDepartmentIdAsync(departmentId);
        }

        public async Task<List<RiskDraftDTO>> GetAllDraftsByCreatedUserAsync(int createdBy)
        {
            return await _riskMongoService.GetAllDraftsByCreatedUserAsync(createdBy);
        }
















    }
}



















