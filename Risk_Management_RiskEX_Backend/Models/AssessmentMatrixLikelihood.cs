using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class AssessmentMatrixLikelihood : TimeStamps
    {
        [Key]
        public int Id { get; set; }
        public string AssessmentFactor { get; set; }
        public double Likelihood { get; set; }
        public string Definition { get; set; }
        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
