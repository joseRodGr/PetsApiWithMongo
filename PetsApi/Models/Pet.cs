
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PetsApi.Models
{
    [BsonIgnoreExtraElements]
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("animalType")]
        public string AnimalType { get; set; }

        [BsonElement("breed")]
        public string Breed { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("weight")]
        public double Weight { get; set; }

        [BsonElement("owner")]
        public Owner Owner { get; set; }

        [BsonElement("vaccines")]
        public ICollection<Vaccine> Vaccines { get; set; } = Array.Empty<Vaccine>();
    }
}



