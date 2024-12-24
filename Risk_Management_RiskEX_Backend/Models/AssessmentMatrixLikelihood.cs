using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
    public class AssessmentMatrixLikelihood : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string AssessmentFactor { get; set; }
        public double Likelihood { get; set; }
    }
}
