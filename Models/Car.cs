using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarYardApi.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Brand")]
        public string CarBrand { get; set; }


        public string CarModel { get; set; }
    }
}