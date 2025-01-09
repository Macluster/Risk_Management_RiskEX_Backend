namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskAssessmentReportDTO
    {
        public int Id { get; set; }
        public string MatrixLikelihood { get; set; }
        public string MatrixImpact { get; set; }
        public string AssessmentBasis { get; set; }
        public string Reviewer { get; set; } // Combine User/ExternalReviewer info as needed
        public string ReviewStatus { get; set; }
        public bool IsMitigated { get; set; }
        public int RiskFactor { get; set; }
    }
}
