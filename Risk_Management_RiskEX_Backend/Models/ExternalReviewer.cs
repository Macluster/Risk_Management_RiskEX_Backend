﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiskManagement_Department_API.Models
{
    public class ExternalReviewer : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
