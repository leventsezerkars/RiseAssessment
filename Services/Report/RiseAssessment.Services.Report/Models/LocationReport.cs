using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RiseAssessment.Services.Report.Models
{
    public class LocationReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Status { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime FinishedDate { get; set; }
    }
}
