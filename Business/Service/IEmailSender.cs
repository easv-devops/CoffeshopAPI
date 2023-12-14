using Models.Entities;

namespace Business.Service;

public interface IEmailSender
{
    bool SendMail(Email email);
}