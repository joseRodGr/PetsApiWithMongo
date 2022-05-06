using MongoDB.Bson.Serialization.Attributes;
using PetsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Dtos
{
    [BsonIgnoreExtraElements]
    public class CreatePetDto
    {
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
    }
}
