using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ExternalReviewerDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        //[ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        
    }
}
