using MongoDB.Bson.Serialization.Attributes;

namespace PetsApi.Models
{
    [BsonNoId]
    public class Owner
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
