namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ReviewUpdateDTO
    {
        public int RiskId { get; set; }
        public string ApprovalStatus { get; set; } 
        public string Comments { get; set; }
    }
}
