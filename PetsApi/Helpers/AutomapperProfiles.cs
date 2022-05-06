using AutoMapper;
using PetsApi.Dtos;
using PetsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsApi.Helpers
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CreatePetDto, Pet>();
        }
    }
}
