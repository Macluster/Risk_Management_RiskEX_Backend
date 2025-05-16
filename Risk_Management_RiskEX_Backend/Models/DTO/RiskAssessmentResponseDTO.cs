namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskAssessmentResponseDTO
    {

        public int Id { get; set; }
        public Object Review { get; set; }
        public AssessmentBasisResponseDTO AssessmentBasis { get; set; }
        public int RiskFactor { get; set; }
        public bool IsMitigated { get; set; }
        public Object ImpactMatix { get; set; }
        public Object LikelihoodMatrix { get; set; }

       
    }
}
