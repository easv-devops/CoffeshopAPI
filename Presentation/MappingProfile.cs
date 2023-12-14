using AutoMapper;
using Models;
using Models.Entities;
using Models.Entities.DTOs;
using Cookie = System.Net.Cookie;

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
        
        CreateMap<Order, CreateOrderDto>();
        CreateMap<CreateOrderDto, Order>();
        
        CreateMap<Cookie, CreateCookieDto>();
        CreateMap<CreateCookieDto, Cookie>();
        
        CreateMap<User, UpdateUserDto>();
        CreateMap<UpdateUserDto, User>();
        
        CreateMap<User, GetUserDto>();
        CreateMap<GetUserDto, User>();
        
        CreateMap<Order, UpdateOrderDto>();
        CreateMap<UpdateOrderDto, Order>();
        
        CreateMap<OrderDetail, CreateOrderDetailDto>();
        CreateMap<CreateOrderDetailDto, OrderDetail>();
        
        CreateMap<Order, GetOrderDto>();
        CreateMap<GetOrderDto, Order>();
        
        CreateMap<Comment, CreateCommentDto>();
        CreateMap<CreateCommentDto, Comment>();
        
    }
}