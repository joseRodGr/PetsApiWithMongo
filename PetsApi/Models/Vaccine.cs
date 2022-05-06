using MongoDB.Bson.Serialization.Attributes;

namespace PetsApi.Models
{
    [BsonNoId]
    public class Vaccine
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
