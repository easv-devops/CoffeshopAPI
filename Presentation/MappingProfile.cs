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
        
        CreateMap<Addition, CreateAdditionDTO>();
        CreateMap<CreateAdditionDTO, Addition>();
        
        CreateMap<BrewingMethod, CreateBrewingMethodDTO>();
        CreateMap<CreateBrewingMethodDTO, BrewingMethod>();
        
        CreateMap<CoffeeBean, CreateCoffeeBeanDTO>();
        CreateMap<CreateCoffeeBeanDTO, CoffeeBean>();
        
        CreateMap<PickupLocation, CreatePickupLocationDTO>();
        CreateMap<CreatePickupLocationDTO, PickupLocation>();
        
        CreateMap<User, CreateUserDTO>();
        CreateMap<CreateUserDTO, User>();
    }
}