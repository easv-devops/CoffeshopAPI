﻿using AutoMapper;
using Models;
using Models.Entities;
using Models.Entities.DTOs;

namespace Presentation;

public class MappingProfile :  Profile
{
    public MappingProfile()
    {

        CreateMap<CreatePredefinedCoffeeDto, PredefinedCoffee>();
        CreateMap<PredefinedCoffee, CreatePredefinedCoffeeDto>();
        
        CreateMap<Addition, CreateAdditionDto>();
        CreateMap<CreateAdditionDto, Addition>();
        
        CreateMap<BrewingMethod, CreateBrewingMethodDto>();
        CreateMap<CreateBrewingMethodDto, BrewingMethod>();
        
        CreateMap<CoffeeBean, CreateCoffeeBeanDto>();
        CreateMap<CreateCoffeeBeanDto, CoffeeBean>();
        
        CreateMap<PickupLocation, CreatePickupLocationDto>();
        CreateMap<CreatePickupLocationDto, PickupLocation>();
        
        CreateMap<User, CreateUserDto>();
        CreateMap<CreateUserDto, User>();
    }
}