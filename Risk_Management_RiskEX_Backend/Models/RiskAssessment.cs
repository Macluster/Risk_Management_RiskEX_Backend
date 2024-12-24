using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
    public class RiskAssessment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Likelihood { get; set; }
        public int Impact { get; set; }
        public int AssessmentBasis { get; set; }
        public int RiskId { get; set; }
        public int RiskFactor { get; set; }
        public bool IsMitigated { get; set; }
        public int ReviewId { get; set; }

        [ForeignKey("RiskId")]
        public virtual Risk Risk { get; set; }

        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

        [ForeignKey("Likelihood")]
        public virtual AssessmentMatrixLikelihood MatrixLikelihood { get; set; }

        [ForeignKey("Impact")]
        public virtual AssessmentMatrixImpact MatrixImpact { get; set; }

        [ForeignKey("AssessmentBasis")]
        public virtual AssessmentBasis Basis { get; set; }
    }
}
