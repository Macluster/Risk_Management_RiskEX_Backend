using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskForApprovalDTO
    {
       
        public int Id { get; set; }
        public string RiskId { get; set; }

      
        public string RiskName { get; set; }


        public string Description { get; set; }
        public RiskType RiskType { get; set; }
        public int OverallRiskRating { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public RiskStatus? RiskStatus { get; set; }
    }
}
