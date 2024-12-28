using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class AssessmentBasis : TimeStamps
    {
        [Key]
        public int Id { get; set; }
        public string Basis { get; set; }

        [JsonIgnore]
        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
