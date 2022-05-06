using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Dtos;
using PetsApi.Models;
using PetsApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAllPets()
        {
            return Ok(await _petService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetPet")]
        public async Task<ActionResult<Pet>> GetPetById(string id)
        {
            var pet = await _petService.GetByIdAsync(id);

            if (pet == null) return NotFound();

            return pet;
        } 

        [HttpPost]
        public async Task<ActionResult<Pet>> CreatePet(CreatePetDto createPet)
        {

            var pet = _mapper.Map<Pet>(createPet);

            await _petService.CreateAsync(pet);

            return CreatedAtRoute("GetPet", new { id = pet.Id }, pet);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePet(string id, Pet pet)
        {
            if (id != pet.Id) return NotFound();

            var existingPet = await _petService.GetByIdAsync(id);

            if (existingPet == null) return NotFound();

            await _petService.UpdateAsync(id, pet);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePet(string id)
        {
            var pet = await _petService.GetByIdAsync(id);

            if (pet == null) return BadRequest();

            await _petService.DeleteAsync(id);

            return NoContent();
        }
    }
}
