namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskUpdateDTO
    {
        public DateTime? ClosedDate { get; set; }
        public int? RiskResponseId { get; set; }
        public RiskStatus? RiskStatus { get; set; }
        public List<RiskAssessmentDTO> RiskAssessments { get; set; }
    }
}
