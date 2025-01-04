using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ApprovalDTO
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string RiskId { get; set; }

        [StringLength(50)]
        public string RiskName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public string RiskType { get; set; }
        public int OverallRiskRating { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public string RiskStatus { get; set; }

    }
}
