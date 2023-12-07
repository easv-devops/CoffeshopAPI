using AutoMapper;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/")]
public class AdditionController : Controller
{
    private readonly IAdditionService _additionService;
    private readonly IMapper _mapper;

    public AdditionController(IAdditionService additionService, IMapper mapper)
    {
        _additionService = additionService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetCookies")]
    public ActionResult<IEnumerable<Cookie>> GetCookies()
    {
        var cookies = _additionService.GetCookies();
        return Ok(cookies);
    }

    [HttpGet("Cookie/{id}")]
    public ActionResult<Cookie> GetCookie(Guid id)
    {
        var cookie = _additionService.GetCookie(id);
        if (cookie == null)
        {
            return NotFound();
        }

        return Ok(cookie);
    }
    
    [HttpGet("CookiesByCoffee/{id}")]
    public ActionResult<IEnumerable<Cookie>> GetCookiesByCoffee(Guid id)
    {
        var cookies = _additionService.GetCookiesByCoffee(id);
        return Ok(cookies);
    }

    [HttpPut("Cookie/{id}")]
    public ActionResult<Cookie> UpdateCookie(Guid id, Cookie cookie)
    {
        if (id != cookie.Id)
        {
            return BadRequest();
        }

        if (!_additionService.CookieExists(id))
        {
            return NotFound();
        }

        var updatedCookie = _additionService.UpdateCookie(id, cookie);
        return Ok(updatedCookie);
    }

    [HttpDelete("Cookie/{id}")]
    public ActionResult DeleteCookie(Guid id)
    {
        if (!_additionService.CookieExists(id))
        {
            return NotFound();
        }

        _additionService.DeleteCookie(id);
        return Ok();
    }

    [HttpPost("Cookie")]
    public ActionResult<Cookie> CreateCookie([FromBody] CreateCookieDto createCookieDto)
    {
        var cookie = new Cookie();
        _mapper.Map(createCookieDto, cookie);
        var createdCookie = _additionService.CreateCookie(cookie);
        return CreatedAtAction(nameof(GetCookie), new {id = createdCookie.Id}, createdCookie);
    }

    [HttpGet]
    [Route ("GetAdditions")]
    public ActionResult<IEnumerable<Addition>> GetAdditions()
    {
        var additions = _additionService.GetAdditions();
        return Ok(additions);
    }

    [HttpGet("Addition/{id}")]
    public ActionResult<Addition> GetAddition(Guid id)
    {
        var addition = _additionService.GetAddition(id);
        if (addition == null)
        {
            return NotFound();
        }

        return Ok(addition);
    }
    
    [HttpPut("Addition/{id}")]
    public ActionResult<Addition> UpdateAddition(Guid id, Addition addition)
    {
        if (id != addition.Id)
        {
            return BadRequest();
        }

        if (!_additionService.AdditionExists(id))
        {
            return NotFound();
        }

        var updatedAddition = _additionService.UpdateAddition(id, addition);
        return Ok(updatedAddition);
    }
    
    [HttpDelete("Addition/{id}")]
    public ActionResult DeleteAddition(Guid id)
    {
        if (!_additionService.AdditionExists(id))
        {
            return NotFound();
        }

        _additionService.DeleteAddition(id);
        return Ok();
    }
    
    [HttpPost("Addition")]
    public ActionResult<Addition> CreateAddition([FromBody] CreateAdditionDto createAdditionDto)
    {
        var addition = new Addition();
        _mapper.Map(createAdditionDto, addition);
        var createdAddition = _additionService.CreateAddition(addition);
        return CreatedAtAction(nameof(GetAddition), new {id = createdAddition.Id}, createdAddition);
    }
    
    [HttpGet]
    [Route ("GetCoffeeBeans")]
    public ActionResult<IEnumerable<CoffeeBean>> GetCoffeeBeans()
    {
        var coffeeBeans = _additionService.GetCoffeeBeans();
        return Ok(coffeeBeans);
    }
    
    [HttpGet("CoffeeBean/{id}")]
    public ActionResult<CoffeeBean> GetCoffeeBean(Guid id)
    {
        var coffeeBean = _additionService.GetCoffeeBean(id);
        if (coffeeBean == null)
        {
            return NotFound();
        }

        return Ok(coffeeBean);
    }
    
    [HttpPut("CoffeeBean/{id}")]
    public ActionResult<CoffeeBean> UpdateCoffeeBean(Guid id, CoffeeBean coffeeBean)
    {
        if (id != coffeeBean.Id)
        {
            return BadRequest();
        }

        if (!_additionService.CoffeeBeanExists(id))
        {
            return NotFound();
        }

        var updatedCoffeeBean = _additionService.UpdateCoffeeBean(id, coffeeBean);
        return Ok(updatedCoffeeBean);
    }
    
    [HttpDelete("CoffeeBean/{id}")]
    public ActionResult DeleteCoffeeBean(Guid id)
    {
        if (!_additionService.CoffeeBeanExists(id))
        {
            return NotFound();
        }

        _additionService.DeleteCoffeeBean(id);
        return Ok();
    }
    
    [HttpPost("CoffeeBean")]
    public ActionResult<CoffeeBean> CreateCoffeeBean([FromBody] CreateCoffeeBeanDto createCoffeeBeanDto)
    {
        var coffeeBean = new CoffeeBean();
        _mapper.Map(createCoffeeBeanDto, coffeeBean);
        var createdCoffeeBean = _additionService.CreateCoffeeBean(coffeeBean);
        return CreatedAtAction(nameof(GetCoffeeBean), new {id = createdCoffeeBean.Id}, createdCoffeeBean);
    }
    
    [HttpGet]
    [Route ("GetBrewingMethods")]
    public ActionResult<IEnumerable<BrewingMethod>> GetBrewingMethods()
    {
        var brewingMethods = _additionService.GetBrewingMethods();
        return Ok(brewingMethods);
    }
    
    [HttpGet("BrewingMethod/{id}")]
    public ActionResult<BrewingMethod> GetBrewingMethod(Guid id)
    {
        var brewingMethod = _additionService.GetBrewingMethod(id);
        if (brewingMethod == null)
        {
            return NotFound();
        }

        return Ok(brewingMethod);
    }
    
    [HttpPut("BrewingMethod/{id}")]
    public ActionResult<BrewingMethod> UpdateBrewingMethod(Guid id, BrewingMethod brewingMethod)
    {
        if (id != brewingMethod.Id)
        {
            return BadRequest();
        }

        if (!_additionService.BrewingMethodExists(id))
        {
            return NotFound();
        }

        var updatedBrewingMethod = _additionService.UpdateBrewingMethod(id, brewingMethod);
        return Ok(updatedBrewingMethod);
    }
    
    [HttpDelete("BrewingMethod/{id}")]
    public ActionResult DeleteBrewingMethod(Guid id)
    {
        if (!_additionService.BrewingMethodExists(id))
        {
            return NotFound();
        }

        _additionService.DeleteBrewingMethod(id);
        return Ok();
    }
    
    [HttpPost("BrewingMethod")]
    public ActionResult<BrewingMethod> CreateBrewingMethod([FromBody] CreateBrewingMethodDto createBrewingMethodDto)
    {
        var brewingMethod = new BrewingMethod();
        _mapper.Map(createBrewingMethodDto, brewingMethod);
        var createdBrewingMethod = _additionService.CreateBrewingMethod(brewingMethod);
        return CreatedAtAction(nameof(GetBrewingMethod), new {id = createdBrewingMethod.Id}, createdBrewingMethod);
    }
    
    [HttpGet]
    [Route ("GetPickupLocations")] 
    public ActionResult<IEnumerable<PickupLocation>> GetPickupLocations()
    {
        var pickupLocations = _additionService.GetPickupLocations();
        return Ok(pickupLocations);
    }
    
    [HttpGet("PickupLocation/{id}")]
    public ActionResult<PickupLocation> GetPickupLocation(Guid id)
    {
        var pickupLocation = _additionService.GetPickupLocation(id);
        if (pickupLocation == null)
        {
            return NotFound();
        }

        return Ok(pickupLocation);
    }
    
    [HttpPost ("PickupLocation")]
    public ActionResult<PickupLocation> CreatePickupLocation([FromBody] CreatePickupLocationDto createPickupLocationDto)
    {
        var pickupLocation = new PickupLocation();
        _mapper.Map(createPickupLocationDto, pickupLocation);
        var createdPickupLocation = _additionService.CreatePickupLocation(pickupLocation);
        return CreatedAtAction(nameof(GetPickupLocation), new {id = createdPickupLocation.Id}, createdPickupLocation);
    }
    
}