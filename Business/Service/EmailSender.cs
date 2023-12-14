using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Models.Entities;

namespace Business.Service;
 

public class EmailSender : IEmailSender
{
    private readonly MailSettings _emailSettings;

    public EmailSender(IOptions<MailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public bool SendMail(Email email)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            message.To.Add(new MailboxAddress(email.To, email.To));
            message.Subject = email.Subject;
            message.Body = new TextPart("plain")
            {
                Text = email.Message
            };

            using var emailClient = new SmtpClient();
            emailClient.Connect(_emailSettings.Server, _emailSettings.Port, true);
            emailClient.Authenticate(_emailSettings.UserName, _emailSettings.Password);
            emailClient.Send(message);
            emailClient.Disconnect(true);
            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}