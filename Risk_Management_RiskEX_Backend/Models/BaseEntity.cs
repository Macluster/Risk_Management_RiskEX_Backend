using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models
{
 
        public abstract class BaseEntity
        {
            public DateTime CreatedAt { get; set; }
            public int CreatedById { get; set; }
            public DateTime UpdatedAt { get; set; }
            public int UpdatedById { get; set; }

            [ForeignKey("CreatedById")]
            [JsonIgnore] 
            public virtual User? CreatedBy { get; set; }

        [JsonIgnore]

        [ForeignKey("UpdatedById")]
            public virtual User? UpdatedBy { get; set; }
        }

        public enum RiskType
        {
            Security,
            Privacy,
            Quality
        }

        public enum RiskResponse
        {
            Accept,
            Mitigate,
            Transfer,
            Avoid
        }

        public enum RiskStatus
        {
            Open,
            PostReviewPending,
            Closed
        }

        public enum ReviewStatus
        {
            Approved,
            Pending,
            Rejected
        }
    }

