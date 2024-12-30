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
                PlannedActionDate=r.PlannedActionDate!=null? r.PlannedActionDate.ToString() : "No planned action date set.",
                r.Remarks,
                
              
                RiskStatus=r.RiskStatus.Value.ToString(),
                r.RiskType,
                
                
                RiskAssessments = r.RiskAssessments != null ? r.RiskAssessments.Select(ra => new
                {
                    ra.Id,
                  
                    Review = ra.Review != null ? new 
                    { 
                        ra.Review.Id, 
                        ReviewStatus=ra.Review.ReviewStatus.ToString() ,
                        ra.Review.Comments,
                        reviewerName= ra.Review.ExternalReviewer==null? ra.Review.User.FullName: ra.Review.ExternalReviewer.FullName, 
                    } : null,
                    AssessmentBasis = ra.AssessmentBasis != null ? new { ra.AssessmentBasis.Id, ra.AssessmentBasis.Basis } : null,
               
                    ra.IsMitigated,

                    ImpactMatix = new { Impact= ra.MatrixImpact.AssessmentFactor,Value=ra.MatrixImpact.Impact},
                    LikeliHoodMatix = new { LikeliHood = ra.MatrixLikelihood.AssessmentFactor, Value = ra.MatrixLikelihood.Likelihood},
                   

                }).ToList():null,
                ResponsibleUser = r.ResponsibleUser != null ? new { r.ResponsibleUser.Id, r.ResponsibleUser.FullName } : null,
                Department = r.Department != null ? new { r.Department.Id, r.Department.DepartmentName } : null,
                Project = r.Project != null ? new { r.Project.Id, r.Project.Name } : null,
                CreatedBy=r.CreatedBy !=null? new
                {
                    r.CreatedBy.Id,
                    r.CreatedBy.FullName
                }:null
            })
            .FirstOrDefaultAsync();


            return risk;
        }


        public async Task<Object> GetMitigationStatusOfARisk(int id)
        {
            var assessments = await _db.Assessments.Where(e => e.RiskId == id).ToListAsync();
            var risks =  _db.Risks.Where(e => e.Id == id).Select(s => s.ResponsibleUser).FirstOrDefault();
           
            
        

            foreach(var assessment in assessments)
            {
                if(assessment.IsMitigated)
                {
                    return new {

                        actionBy = risks != null ? risks.FullName : null,
                        isMitigated = true,

                    
                    };
                }
              
            }
            return null;
        }

      


    }
}
