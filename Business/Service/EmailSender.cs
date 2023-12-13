using System.Net;
using System.Net.Mail;

namespace Business.Service;
 
public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Hello");
        }
        var client = new SmtpClient("smtp.gmail.com", 465)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("noreplyMindfactory@gmail.com", "uclynhanraxuzump")
        };
 
        return client.SendMailAsync(
            new MailMessage(from: "noreplyMindfactory@gmail.com",
                to: email,
                subject,
                message
            ));
    }
}