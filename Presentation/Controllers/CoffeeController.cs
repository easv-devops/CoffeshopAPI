using AutoMapper;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Models.Entities;
using Models.Entities.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : Controller
{
    private readonly ICoffeeService _coffeeService;
    private readonly IMapper _mapper;

    public CoffeeController(ICoffeeService coffeeService, IMapper mapper)
    {
        _coffeeService = coffeeService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route ("GetPredefinedCoffees")]
    public ActionResult<IEnumerable<PredefinedCoffee>> GetPredefinedCoffees()
    {
        var coffees = _coffeeService.GetPredefinedCoffees();
        return Ok(coffees);
    }

    [HttpGet("PredefinedCoffee/{id}")]
    public ActionResult<PredefinedCoffee> GetPredefinedCoffee(Guid id)
    {
        var coffee = _coffeeService.GetPredefinedCoffee(id);
        if (coffee == null)
        {
            return NotFound();
        }

        // Convert the byte array to a base64 string for simplicity
        string imageBase64 = Convert.ToBase64String(coffee.Image);

        // Include other coffee details in the response
        var response = new
        {
            Id = coffee.Id,
            Name = coffee.Name,
            Price = coffee.Price,
            Description = coffee.Description,
            Image = imageBase64
        };

        return Ok(response);
    }


    [HttpPut("PredefinedCoffee/{id}")]
    public ActionResult<PredefinedCoffee> UpdatePredefinedCoffee(Guid id, PredefinedCoffee coffee)
    {
        if (id != coffee.Id)
        {
            return BadRequest();
        }

        if (!_coffeeService.PredefinedCoffeeExists(id))
        {
            return NotFound();
        }

        var updatedCoffee = _coffeeService.UpdatePredefinedCoffee(id, coffee);
        return Ok(updatedCoffee);
    }

    [HttpDelete("PredefinedCoffee/{id}")]
    public ActionResult DeletePredefinedCoffee(Guid id)
    {
        if (!_coffeeService.PredefinedCoffeeExists(id))
        {
            return NotFound();
        }

        _coffeeService.DeletePredefinedCoffee(id);
        return NoContent();
    }

    [HttpPost("PredefinedCoffee")]
    public ActionResult<PredefinedCoffee> CreatePredefinedCoffee([FromBody] CreatePredefinedCoffeeDto coffeeDto)
    {
        try
        {
            // Convert base64 string to byte array
            byte[] imageBytes = Convert.FromBase64String(coffeeDto.Image);

            // Create a PredefinedCoffee object and set properties
            var coffee = new PredefinedCoffee
            {
                // Set other properties based on your requirements
                Name = coffeeDto.Name,
                Description = coffeeDto.Description,
                Image = imageBytes
            };

            // Map additional properties using AutoMapper if needed
            _mapper.Map(coffeeDto, coffee);

            // Create the predefined coffee in the service
            var createdCoffee = _coffeeService.CreatePredefinedCoffee(coffee);

            // Return the created coffee in the response
            return CreatedAtAction(nameof(GetPredefinedCoffee), new { id = createdCoffee.Id }, createdCoffee);
        }
        catch (Exception ex)
        {
            // Handle exceptions, log errors, and return a meaningful response
            return BadRequest($"Failed to create predefined coffee: {ex.Message}");
        }
    }
    
    // Custom coffees
    
    [HttpGet]
    [Route ("GetCustomCoffees")]
    public ActionResult<IEnumerable<CustomCoffee>> GetCustomCoffees()
    {
        var coffees = _coffeeService.GetCustomCoffees();
        return Ok(coffees);
    }

    [HttpGet("CustomCoffee/{id}")]
    public ActionResult<CustomCoffee> GetCustomCoffee(Guid id)
    {
        var coffee = _coffeeService.GetPredefinedCoffee(id);
        if (coffee == null)
        {
            return NotFound();
        }

        return Ok(coffee);
    }

    [HttpPut("CustomCoffee/{id}")]
    public ActionResult<CustomCoffee> UpdateCustomCoffee(Guid id, CustomCoffee coffee)
    {
        if (id != coffee.Id)
        {
            return BadRequest();
        }

        if (!_coffeeService.CustomCoffeeExists(id))
        {
            return NotFound();
        }

        var updatedCoffee = _coffeeService.UpdateCustomCoffee(id, coffee);
        return Ok(updatedCoffee);
    }

    [HttpDelete("CustomCoffee/{id}")]
    public ActionResult DeleteCustomCoffee(Guid id)
    {
        if (!_coffeeService.CustomCoffeeExists(id))
        {
            return NotFound();
        }

        _coffeeService.DeleteCustomCoffee(id);
        return NoContent();
    }

    [HttpPost("CustomCoffee")]
    public ActionResult<CustomCoffee> CreateCustomCoffee(CustomCoffee coffee)
    {
        var createdCoffee = _coffeeService.CreateCustomCoffee(coffee);
        return CreatedAtAction(nameof(GetCustomCoffee), new {id = createdCoffee.Id}, createdCoffee);
    }
}