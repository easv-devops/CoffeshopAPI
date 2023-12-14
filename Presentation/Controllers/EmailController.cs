using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Presentation.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
 
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("SendMail")]
        public ActionResult SendEmail(Email email)
        {
            Console.Write(email.Message);
            _emailSender.SendMail(email);
            return Ok();
        }
    }