using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
    public class Risk : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string RiskId { get; set; }

        [StringLength(50)]
        public string RiskName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public RiskType RiskType { get; set; }

        [StringLength(1000)]
        public string Impact { get; set; }

        [StringLength(1000)]
        public string Mitigation { get; set; }

        [StringLength(1000)]
        public string Contingency { get; set; }

        public int OverallRiskRating { get; set; }
        public int ResponsibleUserId { get; set; }
        public DateTime? PlannedActionDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public RiskResponse RiskResponse { get; set; }
        public RiskStatus RiskStatus { get; set; }
        public string Remarks { get; set; }
        public int DepartmentId { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ResponsibleUserId")]
        public virtual User ResponsibleUser { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }


        public ICollection<RiskAssessment> RiskAssessments { get; set; }
    }
}
