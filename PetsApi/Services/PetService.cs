using MongoDB.Driver;
using PetsApi.Data;
using PetsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Services
{
    public class PetService : IPetService
    {
        private readonly IMongoCollection<Pet> _pets;

        public PetService(IPetStoreDataSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Database);
            _pets = database.GetCollection<Pet>(settings.Collection);
        }
        public async Task<Pet> CreateAsync(Pet pet)
        {
            await _pets.InsertOneAsync(pet);
            return pet;
        }

        public async Task DeleteAsync(string id)
        {
            await _pets.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await _pets.FindAsync(p => true).Result.ToListAsync();
        }

        public async Task<Pet> GetByIdAsync(string id)
        {
            return await _pets.FindAsync(p => p.Id == id).Result.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Pet pet)
        {
            await _pets.ReplaceOneAsync(p => p.Id == id, pet); 
        }
    }
}
