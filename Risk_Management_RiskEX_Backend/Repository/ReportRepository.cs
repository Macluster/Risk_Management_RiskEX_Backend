﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ReportRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReportDTO>> GetAllRisk(String riskStatus)
        {
            if (string.IsNullOrWhiteSpace(riskStatus))
            {
                var reports = await _context.Risks
                    .Select(r => new ReportDTO
                    {
                        Id = r.Id,
                        RiskId = r.RiskId,
                        RiskName = r.RiskName,
                        Description = r.Description,
                        RiskType = r.RiskType.ToString(),
                        Impact = r.Impact,
                        Mitigation = r.Mitigation,
                        Contingency = r.Contingency,
                        OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                        OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                        ResponsibleUserId = r.ResponsibleUserId,
                        ResponsibleUser = r.ResponsibleUser.FullName,
                        ResidualValue = r.ResidualValue,
                        PercentageRedution = r.PercentageRedution,
                        ResidualRisk = r.ResidualRisk.ToString(),
                        PlannedActionDate = r.PlannedActionDate,
                        ClosedDate = r.ClosedDate,
                        RiskResponse = r.RiskResponseData.Name,
                        RiskStatus = r.RiskStatus.ToString(),
                        Remarks = r.Remarks,
                        DepartmentId = r.DepartmentId,
                        ProjectId = r.Project.Id,
                        DepartmentName = r.Department.DepartmentName,
                        RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                        {
                            Id = ra.Id,
                            MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                            MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                            AssessmentBasis = ra.AssessmentBasis.Basis,
                            Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                            ReviewStatus = ra.Review.ReviewStatus.ToString(),
                            IsMitigated = ra.IsMitigated,
                            RiskFactor = ra.RiskFactor

                        }).ToList(),
                        Email = r.ResponsibleUser.Email,
                        CreatedBy = r.CreatedBy.FullName,
                        CreatedAt = r.CreatedAt.ToString(),
                        UpdatedBy = r.UpdatedBy.FullName,
                        UpdatedAt = r.UpdatedAt.ToString()

                    })
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return reports;
            }
            else
            {
                if (!Enum.TryParse(riskStatus, true, out RiskStatus status))
                {
                    throw new ArgumentException($"Invalid RiskType value: {riskStatus}");
                }
                
                var reports = await _context.Risks
                    .Where(r => r.RiskStatus == status)
                    .Select(r => new ReportDTO
                    {
                        Id = r.Id,
                        RiskId = r.RiskId,
                        RiskName = r.RiskName,
                        Description = r.Description,
                        RiskType = r.RiskType.ToString(),
                        Impact = r.Impact,
                        Mitigation = r.Mitigation,
                        Contingency = r.Contingency,
                        OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                        OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                        ResponsibleUserId = r.ResponsibleUserId,
                        ResponsibleUser = r.ResponsibleUser.FullName,
                        ResidualValue = r.ResidualValue,
                        PercentageRedution = r.PercentageRedution,
                        ResidualRisk = r.ResidualRisk.ToString(),
                        PlannedActionDate = r.PlannedActionDate,
                        ClosedDate = r.ClosedDate,
                        RiskResponse = r.RiskResponseData.Name,
                        RiskStatus = r.RiskStatus.ToString(),
                        Remarks = r.Remarks,
                        DepartmentId = r.DepartmentId,
                        ProjectId = r.Project.Id,
                        DepartmentName = r.Department.DepartmentName,
                        RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                        {
                            Id = ra.Id,
                            MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                            MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                            AssessmentBasis = ra.AssessmentBasis.Basis,
                            Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                            ReviewStatus = ra.Review != null ? ra.Review.ReviewStatus.ToString() : "No Status",
                            IsMitigated = ra.IsMitigated,
                            RiskFactor = ra.RiskFactor
                        }).ToList(),
                        Email = r.ResponsibleUser.Email,
                        CreatedBy = r.CreatedBy.FullName,
                        CreatedAt = r.CreatedAt.ToString(),
                        UpdatedBy = r.UpdatedBy.FullName,
                        UpdatedAt = r.UpdatedAt.ToString()
                    })
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return reports;
            }
        }

        public async Task<IEnumerable<ReportDTO>> GetAllRiskByDepartmentId(int id, String riskStatus)
        {
            if (string.IsNullOrWhiteSpace(riskStatus))
            {

                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    throw new ArgumentException("Department not found.");
                }

                var reports = await _context.Risks
                    .Where(r => r.DepartmentId == id)
                    .Select(r => new ReportDTO
                    {
                        Id = r.Id,
                        RiskId = r.RiskId,
                        RiskName = r.RiskName,
                        Description = r.Description,
                        RiskType = r.RiskType.ToString(),
                        Impact = r.Impact,
                        Mitigation = r.Mitigation,
                        Contingency = r.Contingency,
                        OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                        OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                        ResponsibleUserId = r.ResponsibleUserId,
                        ResponsibleUser = r.ResponsibleUser.FullName,
                        ResidualValue = r.ResidualValue,
                        PercentageRedution = r.PercentageRedution,
                        ResidualRisk = r.ResidualRisk.ToString(),
                        PlannedActionDate = r.PlannedActionDate,
                        ClosedDate = r.ClosedDate,
                        RiskResponse = r.RiskResponseData.Name,
                        RiskStatus = r.RiskStatus.ToString(),
                        Remarks = r.Remarks,
                        DepartmentId = r.DepartmentId,
                        ProjectId = r.Project.Id,
                        DepartmentName = r.Department.DepartmentName,
                        RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                        {
                            Id = ra.Id,
                            MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                            MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                            AssessmentBasis = ra.AssessmentBasis.Basis,
                            Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                            ReviewStatus = ra.Review != null ? ra.Review.ReviewStatus.ToString() : "No Status",
                            IsMitigated = ra.IsMitigated,
                            RiskFactor = ra.RiskFactor
                        }).ToList(),
                        Email = r.ResponsibleUser.Email,
                        CreatedBy = r.CreatedBy.FullName,
                        CreatedAt = r.CreatedAt.ToString(),
                        UpdatedBy = r.UpdatedBy.FullName,
                        UpdatedAt = r.UpdatedAt.ToString()
                    })
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return reports;
            }
            else
            {
                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    throw new ArgumentException("Department not found.");
                }

                if (!Enum.TryParse(riskStatus, true, out RiskStatus status))
                {
                    throw new ArgumentException($"Invalid RiskType value: {riskStatus}");
                }
               
                var reports = await _context.Risks
                    .Where(r => r.DepartmentId == id)
                    .Where(r => r.RiskStatus == status)
                    .Select(r => new ReportDTO
                    {
                        Id = r.Id,
                        RiskId = r.RiskId,
                        RiskName = r.RiskName,
                        Description = r.Description,
                        RiskType = r.RiskType.ToString(),
                        Impact = r.Impact,
                        Mitigation = r.Mitigation,
                        Contingency = r.Contingency,
                        OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                        OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                        ResponsibleUserId = r.ResponsibleUserId,
                        ResponsibleUser = r.ResponsibleUser.FullName,
                        ResidualValue = r.ResidualValue,
                        PercentageRedution = r.PercentageRedution,
                        ResidualRisk = r.ResidualRisk.ToString(),
                        PlannedActionDate = r.PlannedActionDate,
                        ClosedDate = r.ClosedDate,
                        RiskResponse = r.RiskResponseData.Name,
                        RiskStatus = r.RiskStatus.ToString(),
                        Remarks = r.Remarks,
                        DepartmentId = r.DepartmentId,
                        ProjectId = r.Project.Id,
                        DepartmentName = r.Department.DepartmentName,
                        RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                        {
                            Id = ra.Id,
                            MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                            MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                            AssessmentBasis = ra.AssessmentBasis.Basis,
                            Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                            ReviewStatus = ra.Review != null ? ra.Review.ReviewStatus.ToString() : "No Status",
                            IsMitigated = ra.IsMitigated,
                            RiskFactor = ra.RiskFactor
                        }).ToList(),
                        Email = r.ResponsibleUser.Email,
                        CreatedBy = r.CreatedBy.FullName,
                        CreatedAt = r.CreatedAt.ToString(),
                        UpdatedBy = r.UpdatedBy.FullName,
                        UpdatedAt = r.UpdatedAt.ToString()
                    })
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return reports;
            }
        }

        public async Task<IEnumerable<ReportDTO>> GetAllClosedRisk()
        {
            
            var reports = await _context.Risks
                .Where(r => r.RiskStatus == RiskStatus.close)
                .Select(r => new ReportDTO
                {
                    Id = r.Id,
                    RiskId = r.RiskId,
                    RiskName = r.RiskName,
                    Description = r.Description,
                    RiskType = r.RiskType.ToString(),
                    Impact = r.Impact,
                    Mitigation = r.Mitigation,
                    Contingency = r.Contingency,
                    OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                    OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                    ResponsibleUserId = r.ResponsibleUserId,
                    ResponsibleUser = r.ResponsibleUser.FullName,
                    ResidualValue = r.ResidualValue,
                    PercentageRedution = r.PercentageRedution,
                    ResidualRisk = r.ResidualRisk.ToString(),
                    PlannedActionDate = r.PlannedActionDate,
                    ClosedDate = r.ClosedDate,
                    RiskResponse = r.RiskResponseData.Name,
                    RiskStatus = r.RiskStatus.ToString(),
                    Remarks = r.Remarks,
                    DepartmentId = r.DepartmentId,
                    ProjectId = r.Project.Id,
                    DepartmentName = r.Department.DepartmentName,
                    RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                    {
                        Id = ra.Id,
                        MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                        MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                        AssessmentBasis = ra.AssessmentBasis.Basis,
                        Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                        ReviewStatus = ra.Review != null ? ra.Review.ReviewStatus.ToString() : "No Status",
                        IsMitigated = ra.IsMitigated,
                        RiskFactor =ra.RiskFactor
                    }).ToList(),
                    Email = r.ResponsibleUser.Email,
                    CreatedBy = r.CreatedBy.FullName,
                    CreatedAt = r.CreatedAt.ToString(),
                    UpdatedBy = r.UpdatedBy.FullName,
                    UpdatedAt = r.UpdatedAt.ToString()
                })
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return reports;
        }

        public async Task<List<ReportDTO>> GetRisksByUserProjects(List<int> projectIds, String riskStatus)
        {
            if (string.IsNullOrWhiteSpace(riskStatus))
            {
                if (projectIds == null || !projectIds.Any())
                {
                    return new List<ReportDTO>(); 
                }

                var risks = await _context.Risks
                    .Where(r => r.ProjectId.HasValue && projectIds.Contains(r.ProjectId.Value))
                    .Select(r => new ReportDTO
                    {

                        Id = r.Id,
                        RiskId = r.RiskId,
                        RiskName = r.RiskName,
                        Description = r.Description,
                        RiskType = r.RiskType.ToString(),
                        Impact = r.Impact,
                        Mitigation = r.Mitigation,
                        Contingency = r.Contingency,
                        OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                        OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                        ResponsibleUserId = r.ResponsibleUserId,
                        ResponsibleUser = r.ResponsibleUser.FullName,
                        ResidualValue = r.ResidualValue,
                        PercentageRedution = r.PercentageRedution,
                        ResidualRisk = r.ResidualRisk.ToString(),
                        PlannedActionDate = r.PlannedActionDate,
                        ClosedDate = r.ClosedDate,
                        RiskResponse = r.RiskResponseData.Name,
                        RiskStatus = r.RiskStatus.ToString(),
                        Remarks = r.Remarks,
                        DepartmentId = r.DepartmentId,
                        ProjectId = r.ProjectId ?? 0,
                        DepartmentName = r.Department.DepartmentName,
                        RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                        {
                            Id = ra.Id,
                            MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                            MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                            AssessmentBasis = ra.AssessmentBasis.Basis,
                            Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                            ReviewStatus = ra.Review != null ? ra.Review.ReviewStatus.ToString() : "No Status",
                            IsMitigated = ra.IsMitigated,
                            RiskFactor = ra.RiskFactor
                        }).ToList(),
                        Email = r.ResponsibleUser.Email,
                        CreatedBy = r.CreatedBy.FullName,
                        CreatedAt = r.CreatedAt.ToString(),
                        UpdatedBy = r.UpdatedBy.FullName,
                        UpdatedAt = r.UpdatedAt.ToString()
                    })
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return risks;
            }
            else
            {
                if (projectIds == null || !projectIds.Any())
                {
                    return new List<ReportDTO>(); 
                }
                if (!Enum.TryParse(riskStatus, true, out RiskStatus status))
                {
                    throw new ArgumentException($"Invalid RiskType value: {riskStatus}");
                }

                var risks = await _context.Risks
                    .Where(r => r.ProjectId.HasValue && projectIds.Contains(r.ProjectId.Value)) 
                    .Where(r => r.RiskStatus == status)
                    .Select(r => new ReportDTO
                    {

                        Id = r.Id,
                        RiskId = r.RiskId,
                        RiskName = r.RiskName,
                        Description = r.Description,
                        RiskType = r.RiskType.ToString(),
                        Impact = r.Impact,
                        Mitigation = r.Mitigation,
                        Contingency = r.Contingency,
                        OverallRiskRatingBefore = r.OverallRiskRatingBefore,
                        OverallRiskRatingAfter = r.OverallRiskRatingAfter,
                        ResponsibleUserId = r.ResponsibleUserId,
                        ResponsibleUser = r.ResponsibleUser.FullName,
                        ResidualValue = r.ResidualValue,
                        PercentageRedution = r.PercentageRedution,
                        ResidualRisk = r.ResidualRisk.ToString(),
                        PlannedActionDate = r.PlannedActionDate,
                        ClosedDate = r.ClosedDate,
                        RiskResponse = r.RiskResponseData.Name,
                        RiskStatus = r.RiskStatus.ToString(),
                        Remarks = r.Remarks,
                        DepartmentId = r.DepartmentId,
                        ProjectId = r.ProjectId ?? 0,
                        DepartmentName = r.Department.DepartmentName,
                        RiskAssessments = r.RiskAssessments.Select(ra => new RiskAssessmentReportDTO
                        {
                            Id = ra.Id,
                            MatrixLikelihood = ra.MatrixLikelihood.AssessmentFactor,
                            MatrixImpact = ra.MatrixImpact.AssessmentFactor,
                            AssessmentBasis = ra.AssessmentBasis.Basis,
                            Reviewer = ra.Review.User.FullName != null ? ra.Review.User.FullName : ra.Review.ExternalReviewer.FullName,
                            ReviewStatus = ra.Review != null ? ra.Review.ReviewStatus.ToString() : "No Status",
                            IsMitigated = ra.IsMitigated,
                            RiskFactor = ra.RiskFactor
                        }).ToList(),
                        Email = r.ResponsibleUser.Email,
                        CreatedBy = r.CreatedBy.FullName,
                        CreatedAt = r.CreatedAt.ToString(),
                        UpdatedBy = r.UpdatedBy.FullName,
                        UpdatedAt = r.UpdatedAt.ToString()
                    })
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();

                return risks;
            }

        }


        
    }
}
