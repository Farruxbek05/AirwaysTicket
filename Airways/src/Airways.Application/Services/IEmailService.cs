using Airways.Application.Common.Email;
using Airways.Application.Models;
using Airways.Core.Entity;
using System.Net.Mail;

namespace Airways.Application.Services
{
    public interface IEmailService
    {
        Task<ApiResult> SendEmailAsync(User user);
    }
}
