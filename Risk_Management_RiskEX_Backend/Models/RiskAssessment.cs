using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class RiskAssessment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Likelihood { get; set; }
        public int Impact { get; set; }
        public int AssessmentBasisId { get; set; }
        public int RiskId { get; set; }
        public int RiskFactor { get; set; }
        public bool IsMitigated { get; set; }
        public int ReviewId { get; set; }

        [ForeignKey("RiskId")]
        public  Risk Risk { get; set; }

        [ForeignKey("ReviewId")]
        public  Review Review { get; set; }

        [ForeignKey("Likelihood")]
        public  AssessmentMatrixLikelihood MatrixLikelihood { get; set; }

        [ForeignKey("Impact")]
        public  AssessmentMatrixImpact MatrixImpact { get; set; }

        [ForeignKey("AssessmentBasisId")]
        public  AssessmentBasis AssessmentBasis { get; set; }
    }
}
