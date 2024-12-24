using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(30)]
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
