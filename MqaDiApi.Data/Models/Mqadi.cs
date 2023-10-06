using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MqaDiApi.Data.Models
{
    public class Mqadi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; } = 1;
        public bool Done { get; set; } = false;
        public DateTime CreatedUTC { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
    }
}
