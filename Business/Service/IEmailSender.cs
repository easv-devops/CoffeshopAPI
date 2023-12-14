using Models.Entities;

namespace Business.Service;

public interface IEmailSender
{
   // Task SendEmailAsync(string email, string subject, string message);

   Task<bool> SendEmailAsync(Email email);
    bool SendMail(Email email);
}