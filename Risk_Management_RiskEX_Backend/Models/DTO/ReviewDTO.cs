namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ReviewDTO
    {
        public int? UserId { get; set; }
        public int? ExternalReviewerId { get; set; }
        public string? Comments { get; set; }
        public ReviewStatus ReviewStatus { get; set; }



    }
}
