using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ReviewDTO
    {
        [BsonElement("UserId")]
        public int? UserId { get; set; }

        [BsonElement("ExternalReviewerId")]
        public int? ExternalReviewerId { get; set; }

        [BsonElement("Comments")]
        public string? Comments { get; set; }

        [BsonElement("ReviewStatus")]
        [BsonRepresentation(BsonType.String)] // Storing as string in MongoDB (you can store it as an integer too)
        public ReviewStatus ReviewStatus { get; set; }
    }
}
