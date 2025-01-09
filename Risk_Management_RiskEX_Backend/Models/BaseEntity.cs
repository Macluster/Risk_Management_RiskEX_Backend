using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models
{

    public abstract class BaseEntity : TimeStamps
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
        Quality = 1,
        Security = 2,
        Privacy = 3

    }

    public enum RiskResponses
    {
        Accept = 1,
        Mitigate = 2,
        Transfer = 3,
        Avoid = 4
    }

    public enum RiskStatus
    {
        open = 1,
        close = 2
    }

    public enum ReviewStatus
    {
        ReviewPending = 1,
        ReviewCompleted = 2,
        ApprovalPending = 3,
        ApprovalCompleted = 4,
        Rejected = 5
        
    }
    public enum ResidualRisk
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}

