using AutoMapper;
using Models;
using Models.Entities;

namespace Presentation;

public class MappingProfile :  Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePredefinedCoffeeDTO, PredefinedCoffee>();
        CreateMap<PredefinedCoffee, CreatePredefinedCoffeeDTO>();
    }
}