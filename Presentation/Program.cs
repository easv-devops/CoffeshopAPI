using System.Text.Json.Serialization;
using Business.Service;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Repository;

namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<CoffeeContext>(opts =>
            opts.UseSqlServer(
                builder.Configuration.GetConnectionString("CoffeeshopDB_EASV")));
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddLogging();
        builder.Services.AddCors();
        
        // Services
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICoffeeService, CoffeeService>();
        builder.Services.AddScoped<IAdditionService, AdditionService>();
        builder.Services.AddScoped<ICommentService, CommentService>();
        
        //Repositories
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        builder.Services.AddScoped<IAdditionRepository, AdditionRepository>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
        app.UseRouting();
        //app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}