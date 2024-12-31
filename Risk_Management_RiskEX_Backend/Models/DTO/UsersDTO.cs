using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class UsersDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public List<string>? ProjectNames { get; set; } 
    }
}
