namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskUpdateDTO
    {
        public DateTime? ClosedDate { get; set; }
        // public int RiskResponseId { get; set; }
        public RiskStatus? RiskStatus { get; set; }
        public int OverallRiskRatingAfter { get; set; }
        public double PercentageRedution { get; set; }
        public ResidualRisk ResidualRisk { get; set; }
        public int ResidualValue { get; set; }
        public string? Remarks { get; set; }


        public List<RiskAssessmentDTO> RiskAssessments { get; set; }
    }
}
