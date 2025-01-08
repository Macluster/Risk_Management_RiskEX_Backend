namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskDetailsDTO
    {
        public int Id { get; set; }
        public string RiskId { get; set; }
        public string RiskName { get; set; }
        public string RiskDepartment { get; set; }
        public string Description { get; set; }
        public string RiskType { get; set; }
        public DateTime PlannedActionDate { get; set; }
        public int OverallRiskRating { get; set; }
        public string RiskStatus { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerDepartment { get; set; }
    }
}
