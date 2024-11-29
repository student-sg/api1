using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace stickwebapi.Models
{
    public class Alert
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("device")]
        public ObjectId Device { get; set; }
        public string DeviceAsString => Device.ToString();

        [BsonElement("type")]
        public string Type { get; set; } = null!;
        
        [BsonElement("message")]
        public string Message { get; set; } = null!;

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("resolved")]
        public bool Resolved { get; set; }
    }
}
