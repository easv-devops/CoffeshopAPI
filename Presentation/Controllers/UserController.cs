using AutoMapper;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route ("GetUsers")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(Guid id)
    {
        var user = _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(Guid id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        if (!_userService.UserExists(id))
        {
            return NotFound();
        }

        var updatedUser = _userService.UpdateUser(id, user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(Guid id)
    {
        if (!_userService.UserExists(id))
        {
            return NotFound();
        }

        _userService.DeleteUser(id);
        return NoContent();
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        var createdUser = _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUser), new {id = createdUser.Id}, createdUser);
    }
}