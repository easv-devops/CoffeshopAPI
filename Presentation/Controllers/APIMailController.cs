using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class APIMailController : ControllerBase
{
    private readonly APIMailService _mailService;
    
    public APIMailController()
    {
        
    }
    
}