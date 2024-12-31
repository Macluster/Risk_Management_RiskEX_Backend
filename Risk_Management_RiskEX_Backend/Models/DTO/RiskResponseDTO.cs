﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskResponseDTO
    {
        public int Id { get; set; }
        public string RiskId { get; set; }
        public string RiskName { get; set; }
        public string Description { get; set; }
        public string Impact { get; set; }
        public string Mitigation { get; set; }
        public string Contingency { get; set; }
        public int OverallRiskRating { get; set; }
        public string PlannedActionDate { get; set; }
        public string Remarks { get; set; }
        public string RiskStatus { get; set; }
        public string RiskType { get; set; }
        public List<RiskAssessmentResponseDTO> RiskAssessments { get; set; }
        public UserResponseDTO ResponsibleUser { get; set; }
        public DepartmentDTO Department { get; set; }
        public ProjectResponseDTO Project { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
