namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskAssessmentDTO
    {
        public int Likelihood { get; set; }
        public int Impact { get; set; }
        public bool IsMitigated { get; set; }
        public int? AssessmentBasisId { get; set; }
        public int RiskFactor { get; set; }

        public ReviewDTO Review { get; set; }
    }
}
