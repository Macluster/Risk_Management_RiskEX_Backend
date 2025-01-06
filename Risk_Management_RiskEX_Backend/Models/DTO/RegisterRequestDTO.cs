using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RegisterRequestDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }

     
        public string? Password { get; set; }

    
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

    }
}
