using Business.Service;
    using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Presentation.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailSender emailSender;
 
        public EmailController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
 
        [HttpPost]
        public async Task<IActionResult> Index(Email email)
        {
            await emailSender.SendEmailAsync(email.To, email.Subject, email.Message);
            return Ok();
        }
    }