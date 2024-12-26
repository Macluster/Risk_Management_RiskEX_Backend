using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(30)]
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }


        public ICollection<Risk> ResponsibleRisks { get; set; }


        // For CreatedBy and edited By
        public ICollection<Risk> CreatedRisks { get; set; }
        public ICollection<Risk> UpdatedRisks { get; set; }

        public ICollection<Project> CreatedProjects { get; set; }
        public ICollection<Project> UpdatedProjects { get; set; }
        public ICollection<Department> CreatedDepartments { get; set; }
        public ICollection<Department> UpdatedDepartments { get; set; }

        public ICollection<RiskAssessment> CreatedRiskAssessments { get; set; }
        public ICollection<RiskAssessment> UpdatedRiskAssessments { get; set; }


        public ICollection<AssessmentBasis> CreatedAssessmentBasis { get; set; }
        public ICollection<AssessmentBasis> UpdatedAssessmentBasis { get; set; }

        public ICollection<AssessmentMatrixLikelihood> CreatedLikeliHoodMatrix { get; set; }
        public ICollection<AssessmentMatrixLikelihood> UpdatedLikeliHoodMatrix{ get; set; }
        public ICollection<AssessmentMatrixImpact> CreatedImpactMatrix { get; set; }
        public ICollection<AssessmentMatrixImpact> UpdatedImpactMatrix{ get; set; }

        public ICollection<ExternalReviewer> CreatedExternalReviewers { get; set; }
        public ICollection<ExternalReviewer> UpdatedExternalReviewers { get; set; }

        public ICollection<Review> CreatedReviews { get; set; }
        public ICollection<Review> UpdatedReviews { get; set; }

        public ICollection<User> CreatedUsers {  get; set; }
        public ICollection<User> UpdatedUsers { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
