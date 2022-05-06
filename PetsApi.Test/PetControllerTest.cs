using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using PetsApi.Controllers;
using PetsApi.Models;
using PetsApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetsApi.Test
{
    public class PetControllerTest
    {
        private readonly PetController _petController;
        private readonly Mock<IPetService> _petServiceMock = new Mock<IPetService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public PetControllerTest()
        {
            _petController = new PetController(_petServiceMock.Object,_mapperMock.Object);
        }

        [Fact]
        public async Task GetPetById_ShouldReturnAPet_WhenPetExist()
        {
            var petId = ObjectId.GenerateNewId().ToString();
            var petName = "Coco";
            var breed = "srd";
            var animalType = "dog";
            var age = 2;
            var weigth = 8.5;
            var owner = new Owner { Id = 123456453, Name = "Jose", Email = "jose@email.com", PhoneNumber = "50611119999" };
            var vaccines = new List<Vaccine>()
            {
                new Vaccine{Id=1, Name="Rabies"},
                new Vaccine{Id=2, Name= "Polyvalent"}
            };

            var pet = new Pet
            {
                Id = petId,
                Name = petName,
                Breed =breed,
                AnimalType = animalType,
                Age = age,
                Weight = weigth,
                Owner = owner,
                Vaccines = vaccines
            };

            _petServiceMock.Setup(x =>  x.GetByIdAsync(petId)).ReturnsAsync(pet);

            var petResult = await _petController.GetPetById(petId);

            Assert.IsType<Pet>(petResult.Value);
            

        }

        [Fact]
        public async Task GetPetById_ShouldReturnNotFound_WhenReceivedPetNotExist()
        {
            var routeId = ObjectId.GenerateNewId().ToString();

            _petServiceMock.Setup(x => x.GetByIdAsync(routeId))
                .ReturnsAsync(() => null);

            var petResult = await _petController.GetPetById(routeId);

            Assert.IsType<NotFoundResult>(petResult.Result);
        }

        [Fact]
        public async Task UpdatePet_ShouldReturnNotFound_WhenRouteIdIsDifferentToPetId()
        {
            var routeId = ObjectId.GenerateNewId().ToString();

            var petId = ObjectId.GenerateNewId().ToString();
            var petName = "Coco";
            var breed = "srd";
            var animalType = "dog";
            var age = 2;
            var weigth = 8.5;
            var owner = new Owner { Id = 123456453, Name = "Jose", Email = "jose@email.com", PhoneNumber = "50611119999" };
            var vaccines = new List<Vaccine>()
            {
                new Vaccine{Id=1, Name="Rabies"},
                new Vaccine{Id=2, Name= "Polyvalent"}
            };

            var pet = new Pet
            {
                Id = petId,
                Name = petName,
                Breed = breed,
                AnimalType = animalType,
                Age = age,
                Weight = weigth,
                Owner = owner,
                Vaccines = vaccines
            };

            var petResult = await _petController.UpdatePet(routeId, pet);

            Assert.IsType<NotFoundResult>(petResult);

        }

        [Fact]
        public async Task UpdatePet_ShouldReturnNotFound_WhenPetNotExist()
        {
            var routeId = ObjectId.GenerateNewId().ToString();

            var petId = routeId;
            var petName = "Coco";
            var breed = "srd";
            var animalType = "dog";
            var age = 2;
            var weigth = 8.5;
            var owner = new Owner { Id = 123456453, Name = "Jose", Email = "jose@email.com", PhoneNumber = "50611119999" };
            var vaccines = new List<Vaccine>()
            {
                new Vaccine{Id=1, Name="Rabies"},
                new Vaccine{Id=2, Name= "Polyvalent"}
            };

            var pet = new Pet
            {
                Id = petId,
                Name = petName,
                Breed = breed,
                AnimalType = animalType,
                Age = age,
                Weight = weigth,
                Owner = owner,
                Vaccines = vaccines
            };

            _petServiceMock.Setup(x => x.GetByIdAsync(routeId)).ReturnsAsync(() => null);

            var petResult = await _petController.UpdatePet(routeId, pet);

            Assert.IsType<NotFoundResult>(petResult);

        }

        [Fact]
        public async Task UpdatePet_ShouldReturnNoContent_WhenPetExistAndIsUpdated()
        {
            var routeId = ObjectId.GenerateNewId().ToString();

            var petId = routeId;
            var petName = "Coco";
            var breed = "srd";
            var animalType = "dog";
            var age = 2;
            var weigth = 8.5;
            var owner = new Owner { Id = 123456453, Name = "Jose", Email = "jose@email.com", PhoneNumber = "50611119999" };
            var vaccines = new List<Vaccine>()
            {
                new Vaccine{Id=1, Name="Rabies"},
                new Vaccine{Id=2, Name= "Polyvalent"}
            };

            var pet = new Pet
            {
                Id = petId,
                Name = petName,
                Breed = breed,
                AnimalType = animalType,
                Age = age,
                Weight = weigth,
                Owner = owner,
                Vaccines = vaccines
            };

            _petServiceMock.Setup(x => x.GetByIdAsync(routeId)).ReturnsAsync(new Pet { Id = routeId});
            _petServiceMock.Setup(x => x.UpdateAsync(routeId, pet));

            var petResult = await _petController.UpdatePet(routeId, pet);

            Assert.IsType<NoContentResult>(petResult);

        }

        [Fact]
        public async Task DeletePet_ShouldReturnBadRequest_WhenPetNotExist()
        {

            var routeId = ObjectId.GenerateNewId().ToString();

            _petServiceMock.Setup(x => x.GetByIdAsync(routeId)).ReturnsAsync(() => null);

            var petResult = await _petController.DeletePet(routeId);

            Assert.IsType<BadRequestResult>(petResult);
        }

        [Fact]
        public async Task DeletePet_ShouldReturnNoContent_WhenPetExist()
        {
            var routeId = ObjectId.GenerateNewId().ToString();

            _petServiceMock.Setup(x => x.GetByIdAsync(routeId)).ReturnsAsync(new Pet { Id = routeId});

            _petServiceMock.Setup(x => x.DeleteAsync(routeId));

            var petResult = await _petController.DeletePet(routeId);

            Assert.IsType<NoContentResult>(petResult);


        }


    }
}
