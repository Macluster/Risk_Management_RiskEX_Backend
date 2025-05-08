using MongoDB.Bson.Serialization.Attributes;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class RiskAssessmentDTO
    {
        [BsonElement("Likelihood")]
        public int Likelihood { get; set; }

        [BsonElement("Impact")]
        public int Impact { get; set; }

        [BsonElement("IsMitigated")]
        public bool IsMitigated { get; set; }

        [BsonElement("AssessmentBasisId")]
        public int? AssessmentBasisId { get; set; }

        [BsonElement("RiskFactor")]
        public int RiskFactor { get; set; }

        [BsonElement("Review")]
        public ReviewDTO Review { get; set; } // Ensure ReviewDTO is serializable
    }
}
