using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class Review : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExternalReviewerId { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }
        public ReviewStatus ReviewStatus { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ExternalReviewerId")]
        public virtual ExternalReviewer ExternalReviewer { get; set; }

        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
