using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models
{
    public class Department : TimeStamps
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public string? NewName { get; set; }

        public string? DepartmentCode { get; set; }
        
        [JsonIgnore]
        public ICollection<Project> Projects { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<ExternalReviewer> ExternalReviewers { get; set; }

        public ICollection<Risk> Risks { get; set; }
    }
}
