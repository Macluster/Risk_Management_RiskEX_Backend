using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
    public class AssessmentBasis : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Basis { get; set; }

        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
