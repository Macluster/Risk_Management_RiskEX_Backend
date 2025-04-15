using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskDraftDTO

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
       
        public string? Id { get; set; }

        [Required]
        [BsonElement("RiskName")]
        public string RiskName { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("RiskType")]
        public RiskType? RiskType { get; set; }

        [BsonElement("Impact")]
        public string? Impact { get; set; }

        [BsonElement("Mitigation")]
        public string? Mitigation { get; set; }

        [BsonElement("Contingency")]
        public string? Contingency { get; set; }

        [BsonElement("OverallRiskRatingBefore")]
        public int? OverallRiskRatingBefore { get; set; }

        [BsonElement("ResponsibleUserId")]
        public int? ResponsibleUserId { get; set; }

        [BsonElement("PlannedActionDate")]
        public DateTime? PlannedActionDate { get; set; }

        [BsonElement("DepartmentId")]
        public int? DepartmentId { get; set; }

        [BsonElement("ProjectId")]
        public int? ProjectId { get; set; }

        [BsonElement("CreatedBy")]
        public int? CreatedBy { get; set; }

        [BsonElement("RiskAssessments")]
        public List<RiskAssessmentDraftDTO> RiskAssessments { get; set; }
    }
}
