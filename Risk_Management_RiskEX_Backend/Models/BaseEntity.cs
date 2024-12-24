using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
 
        public abstract class BaseEntity
        {
            public DateTime CreatedAt { get; set; }
            public int CreatedById { get; set; }
            public DateTime UpdatedAt { get; set; }
            public int UpdatedById { get; set; }

            [ForeignKey("CreatedById")]
            public virtual User CreatedBy { get; set; }

            [ForeignKey("UpdatedById")]
            public virtual User UpdatedBy { get; set; }
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

