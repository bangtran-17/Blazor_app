using Hotel.Shared.Models;

namespace Hotel.Server.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}