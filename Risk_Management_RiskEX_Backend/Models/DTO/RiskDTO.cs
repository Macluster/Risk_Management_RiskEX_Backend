using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;

public class RiskDTO
{
    [BsonId] // If you want to use it as the primary identifier

    public string RiskId { get; set; }

    [BsonElement("RiskName")]
    public string RiskName { get; set; }

    [BsonElement("Description")]
    public string Description { get; set; }

    [BsonElement("RiskType")]
    public RiskType RiskType { get; set; }

    [BsonElement("Impact")]
    public string Impact { get; set; }

    [BsonElement("Mitigation")]
    public string Mitigation { get; set; }

    [BsonElement("Contingency")]
    public string? Contingency { get; set; }

    [BsonElement("OverallRiskRatingBefore")]
    public int OverallRiskRatingBefore { get; set; }

    [BsonElement("ResponsibleUserId")]
    public int ResponsibleUserId { get; set; }

    [BsonElement("PlannedActionDate")]
    public DateTime PlannedActionDate { get; set; }

    [BsonElement("DepartmentId")]
    public int DepartmentId { get; set; }

    [BsonElement("ProjectId")]
    public int? ProjectId { get; set; }

    [BsonElement("ISOClauseNumber")]
     public string? ISOClauseNumber { get; set; }

    [BsonElement("RiskResponseId")]
    public int? RiskResponseId { get; set; }

    [BsonElement("RiskAssessments")]
    public List<RiskAssessmentDTO> RiskAssessments { get; set; }
}

