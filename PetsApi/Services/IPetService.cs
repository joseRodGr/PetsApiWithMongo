using PetsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet> GetByIdAsync(string id);
        Task<Pet> CreateAsync(Pet pet);
        Task UpdateAsync(string id, Pet pet);
        Task DeleteAsync(string id);
    }
}
