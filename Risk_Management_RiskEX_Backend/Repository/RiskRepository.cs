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



        public RiskRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
                Contingency = r.Contingency != null ? r.Contingency : null,
                OverallRiskRating = r.OverallRiskRating,
                PlannedActionDate = r.PlannedActionDate != null ? r.PlannedActionDate.ToString() : "No planned action date set.",
                Remarks = r.Remarks != null ? r.Remarks : null,


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
                ResponsibleUser = r.ResponsibleUser != null ? new UserResponseDTO { Id = r.ResponsibleUser.Id, FullName = r.ResponsibleUser.FullName } : null,
                Department = new DepartmentDTO { Id = r.Department.Id, Name = r.Department.DepartmentName },
                Project = r.Project != null ? new ProjectResponseDTO { Id = r.Project.Id, ProjectName = r.Project.Name } : null,
                CreatedBy = r.CreatedBy.FullName,
                CreatedAt = r.CreatedAt,
                UpdatedBy = r.UpdatedBy != null ? r.UpdatedBy.FullName : null,

                UpdatedAt = r.UpdatedAt
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

            // Query the reviews by userId and specific review status values
            var reviews = await _db.Reviews
                .Where(r => r.UserId == userId &&
                            (r.ReviewStatus == ReviewStatus.ReviewPending || r.ReviewStatus == ReviewStatus.ApprovalPending))
                .Include(r => r.RiskAssessments)
                .ThenInclude(ra => ra.Risk)
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
                existingRisk.OverallRiskRating = riskDto.OverallRiskRating;
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
                    existingRisk.OverallRiskRating = riskDto.OverallRiskRating;
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

                    // Update Risk properties
                    if (riskUpdateDto.ClosedDate.HasValue)
                    {
                        existingRisk.ClosedDate = riskUpdateDto.ClosedDate.Value;
                        existingRisk.RiskStatus = RiskStatus.close; // Set status to closed
                    }

                    if (riskUpdateDto.RiskResponseId.HasValue)
                    {
                        existingRisk.RiskResponseId = riskUpdateDto.RiskResponseId.Value;
                    }

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
                    if (riskUpdateDto.ClosedDate.HasValue)
                    {
                        existingRisk.ClosedDate = riskUpdateDto.ClosedDate.Value;
                        existingRisk.RiskStatus = RiskStatus.close; // Set status to closed
                    }

                    if (riskUpdateDto.RiskResponseId.HasValue)
                    {
                        existingRisk.RiskResponseId = riskUpdateDto.RiskResponseId.Value;
                    }

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

        public async Task<object> GetRiskByAssigneeId(int id)
        {


            var result = await _db.Risks.Where(e => e.ResponsibleUserId == id).ToListAsync();



            var Risks = _mapper.Map<List<RiskForApprovalDTO>>(result);

            return Risks;


        }


        //public Task<ICollection<int>> GetRiskCategoryCounts()
        //{
        //  throw new NotImplementedException();
        //}

        public async Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCounts()
        {
            var riskCategoryCounts = await _db.Set<Risk>()
                .Select(r => new
                {
                    RiskType = r.RiskType.ToString(),
                    OverallRiskRating = r.OverallRiskRating,
                    RiskCategory = r.RiskType == RiskType.Quality
                        ? (r.OverallRiskRating <= 8 ? "Low" :
                           r.OverallRiskRating >= 10 && r.OverallRiskRating <= 32 ? "Moderate" :
                           r.OverallRiskRating >= 40 ? "Critical" : "Uncategorized")
                        : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
                        ? (r.OverallRiskRating <= 45 ? "Low" :
                           r.OverallRiskRating >= 46 && r.OverallRiskRating <= 69 ? "Moderate" :
                           r.OverallRiskRating >= 70 ? "Critical" : "Uncategorized")
                        : "Uncategorized"
                })
                .GroupBy(r => r.RiskCategory)
                .Select(g => new RiskCategoryCountDTO
                {
                    RiskCategory = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            return riskCategoryCounts;
        }

        public async Task<ICollection<OpenRiskCountByTypeDTO>> GetOpenRiskCountByType()
        {
            var riskTypeCounts = await _db.Set<Risk>()
                .GroupBy(r => r.RiskType)
                .Select(g => new OpenRiskCountByTypeDTO
                {
                    RiskType = g.Key.ToString(),
                    RiskCount = g.Count()
                })
                .ToListAsync();

            return riskTypeCounts;
        }

        public async Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCountsByDepartments(List<int> departmentIds)
        {

            var query = _db.Set<Risk>()
              .Where(r => !departmentIds.Any() || departmentIds.Contains(r.DepartmentId))
              .Select(r => new
              {
                  r.DepartmentId,
                  RiskCategory = r.RiskType == RiskType.Quality
                      ? (r.OverallRiskRating <= 8 ? "Low" :
                         r.OverallRiskRating >= 10 && r.OverallRiskRating <= 32 ? "Moderate" :
                         r.OverallRiskRating >= 40 ? "Critical" : "Uncategorized")
                      : (r.RiskType == RiskType.Security || r.RiskType == RiskType.Privacy)
                      ? (r.OverallRiskRating <= 45 ? "Low" :
                         r.OverallRiskRating >= 46 && r.OverallRiskRating <= 69 ? "Moderate" :
                         r.OverallRiskRating >= 70 ? "Critical" : "Uncategorized")
                      : "Uncategorized"
              })
              .GroupBy(r => new
              {
                  DepartmentId = departmentIds.Any() ? r.DepartmentId : 0,
                  r.RiskCategory
              })
              .Select(g => new RiskCategoryCountDTO
              {
                  DepartmentId = g.Key.DepartmentId,
                  RiskCategory = g.Key.RiskCategory,
                  Count = g.Count()
              });

            return await query.ToListAsync();

        }
    

     

        public async Task<Object> RiskApproachingDeadline(int? id)
        {

           if(id== null)
            {
                var closestRisks = await _db.Risks
      
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
                var closestRisks = await _db.Risks
                 .Where(e => e.DepartmentId == id)  
                 .ToListAsync();  

               
                var closestRisksSorted = closestRisks
                    .OrderBy(r => Math.Abs((r.PlannedActionDate - DateTime.Now).Ticks)) 
                    .Take(3) 
                    .ToList();

                
                var data = _mapper.Map<List<RiskMinimalInfoDTO>>(closestRisksSorted);
                return data;
            }
         

           
        }

        public async Task<object> GetRiskWithHeighestOverallRationg(int? id)
        {
           

            if (id == null)
            {
                var highestRatedRisk = await _db.Risks.OrderByDescending(r => r.OverallRiskRating).ToListAsync();
                var data = _mapper.Map<List<RiskMinimalInfoDTO>>(highestRatedRisk);

                return data;
            }
            else
            {
                var highestRatedRisk = await _db.Risks.Where(e=>e.DepartmentId==id).OrderByDescending(r => r.OverallRiskRating).ToListAsync();
                var data = _mapper.Map<List<RiskMinimalInfoDTO>>(highestRatedRisk);

                return data;
            }
          

        
            
        }

    }

}
       








