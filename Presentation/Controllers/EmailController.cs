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
        public ActionResult SendEmail(Email email)
        {
            _emailSender.SendMail(email);
            return Ok();
        }
    }