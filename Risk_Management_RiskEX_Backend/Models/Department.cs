﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RiskManagement_Department_API.Models
{
    public class Department : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        
        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<ExternalReviewer>? ExternalReviewers { get; set; }

        public ICollection<Risk> Risks { get; set; }
    }
}