using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{

    public class AssessmentMatrixImpact : TimeStamps
    {
        [Key]
        public int Id { get; set; }
        public string AssessmentFactor { get; set; }
        public double Impact { get; set; }
        public string Definition { get; set; }
        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
