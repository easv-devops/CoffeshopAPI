using Google.Apis.Http;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Models.Entities;

namespace Business.Service;

public class APIMailService : IApiMailService
{
    private readonly MailSettings _mailSettings;
    private readonly HttpClient _httpClient;
    
    public APIMailService(IOptions<MailSettings> mailSettingsOptions, IHttpClientFactory httpClientFactory)
    {
        _mailSettings = mailSettingsOptions.Value;
    }
    public Task<bool> SendEmailAsync(Email email)
    {
        throw new NotImplementedException();
    }
}