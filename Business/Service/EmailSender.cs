using System.Net;
using System;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Models.Entities;

namespace Business.Service;
 
/*
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

    public bool SendMail(Email email)
    {
        return true;
    }
    */
    
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        public EmailSender(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }

       public async Task<bool> SendEmailAsync(Email email)
        {
            try
            {
                using (var emailMessage = new MimeMessage())
                {
                    emailMessage.From.Add(new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail));
                    emailMessage.To.Add(new MailboxAddress(email.To,email.To));
                    emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                    emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));
                    emailMessage.Subject = email.Subject;

                    var emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = email.Message;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                   
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        await client.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                        await client.SendAsync(emailMessage);
                        await client.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SendMail(Email email)
        {
            throw new NotImplementedException();
        }
    }
    
    
