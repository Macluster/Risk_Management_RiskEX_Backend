namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskDTO
    {
        public string RiskId { get; set; }
        public string RiskName { get; set; }
        public string Description { get; set; }
        public RiskType RiskType { get; set; }
        public string Impact { get; set; }
        public string Mitigation { get; set; }
        public string? Contingency { get; set; }
        public int OverallRiskRatingBefore { get; set; }
        public int ResponsibleUserId { get; set; }
        public DateTime PlannedActionDate { get; set; }
        public int DepartmentId { get; set; }
        public int? ProjectId { get; set; }
        public List<RiskAssessmentDTO> RiskAssessments { get; set; }
    }
}
