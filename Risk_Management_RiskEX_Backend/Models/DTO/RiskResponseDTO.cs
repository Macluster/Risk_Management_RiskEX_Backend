using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskResponseDTO
    {

        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string RiskId { get; set; }

        [StringLength(50)]
        public string RiskName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public RiskType RiskType { get; set; }

        [StringLength(1000)]
        public string Impact { get; set; }

        [StringLength(1000)]
        public string Mitigation { get; set; }

        [StringLength(1000)]
        public string Contingency { get; set; }

        public int OverallRiskRating { get; set; }
        public int ResponsibleUserId { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public RiskResponses RiskResponse { get; set; }
        public RiskStatus RiskStatus { get; set; }
        public string Remarks { get; set; }
        public int DepartmentId { get; set; }
        public int? ProjectId { get; set; }



 
  
        public virtual User ResponsibleUser { get; set; }


      
        public virtual DepartmentDTO Department { get; set; }


   
        public virtual ProjectDTO Project { get; set; }

     

        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
