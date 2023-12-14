using Business.Service;
    using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Presentation.Controllers;

    [ApiController]
    [Route("api/[controller]")]
  //  [Route("[controller]")]
  //  [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
 
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("SendMail")]
        public bool SendEmail(Email email)
        {
            return _emailSender.SendMail(email);
        }
        
        
     /*   [HttpPost]
        public async Task<IActionResult> Index(Email email)
        {
            await emailSender.SendEmailAsync(email.To, email.Subject, email.Message);
            return Ok();
        }*/
    }