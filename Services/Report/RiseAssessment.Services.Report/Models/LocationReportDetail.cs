using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RiseAssessment.Services.Report.Models
{
    public class LocationReportDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}
