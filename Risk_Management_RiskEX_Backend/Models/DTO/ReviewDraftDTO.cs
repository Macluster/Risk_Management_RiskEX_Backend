using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Risk_Management_RiskEX_Backend.Models.DTO
{
    public class ReviewDraftDTO
    {
        [BsonElement("UserId")]
        public int? UserId { get; set; }

        [BsonElement("ExternalReviewerId")]
        public int? ExternalReviewerId { get; set; }

        [BsonElement("Comments")]
        public string ? Comments { get; set; }

        [BsonElement("ReviewStatus")]
       
        public ReviewStatus? ReviewStatus { get; set; }
    }
}
