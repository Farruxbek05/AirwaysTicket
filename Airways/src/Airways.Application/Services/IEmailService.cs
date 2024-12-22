using Airways.Application.Common.Email;
using System.Net.Mail;

namespace Airways.Application.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
