using Models.Entities;

namespace Business.Service;

public interface IApiMailService
{
    Task<bool> SendEmailAsync(Email email);
}