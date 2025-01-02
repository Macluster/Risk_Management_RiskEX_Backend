using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ReportDTO
    {
        [Key]
        public int Id { get; set; }
        public string RiskId { get; set; }
        public string RiskName { get; set; }
        public string Description { get; set; }
        public RiskType RiskType { get; set; }
        public string Impact { get; set; }
        public string Mitigation { get; set; }
        public string? Contingency { get; set; }
        public int OverallRiskRating { get; set; }
        public int ResponsibleUserId { get; set; }
        public string ResponsibleUser { get; set; }
        //public string Reviewer { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string RiskResponse { get; set; }
        //public int? RiskResponseId { get; set; }

        //public RiskStatus? RiskStatus { get; set; }
        public string RiskStatus { get; set; }
        public string? Remarks { get; set; }
        public int DepartmentId { get; set; }
        public int? ProjectId { get; set; }
        public string DepartmentName { get; set; }
        public List<RiskAssessmentReportDTO> RiskAssessments { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }

}

