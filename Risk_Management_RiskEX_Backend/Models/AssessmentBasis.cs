using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class AssessmentBasis : TimeStamps
    {
        [Key]
        public int Id { get; set; }
        public string Basis { get; set; }

        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
