using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{

    public class AssessmentMatrixImpact : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string AssessmentFactor { get; set; }
        public double Impact { get; set; }
    }
}
