using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class Project : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

     

        public ICollection<Risk> Risks { get; set; }
    }
}
