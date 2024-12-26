using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models
{

    public abstract class BaseEntity:TimeStamps
    {
        public int? CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public int? UpdatedById { get; set; }
        [ForeignKey("UpdatedById")]
        public virtual User UpdatedBy { get; set; }
    }


    public enum RiskType
        {
            Security,
            Privacy,
            Quality
        }

        public enum RiskResponses
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

