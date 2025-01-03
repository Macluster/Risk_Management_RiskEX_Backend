namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskDetailsDTO
    {
        public string RiskId { get; set; }
        public string RiskName { get; set; }
        public string RiskDepartment { get; set; }
        public string Description { get; set; }
        public RiskType RiskType { get; set; }
        public DateTime PlannedActionDate { get; set; }
        public int OverallRiskRating { get; set; }
        public RiskStatus RiskStatus { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerDepartment { get; set; }
    }
}
