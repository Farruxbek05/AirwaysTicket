using Airways.Application.Common;
using Airways.Application.Common.Email;
using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Core.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Net;
using System.Net.Mail;

namespace Airways.Application.Services.DevImpl
{
    public class EmailService : IEmailService
    {
        private readonly GoogleSmtpSettings _smtpSettings;
        private readonly IServiceProvider _serviceProvider;

        public EmailService(IOptions<GoogleSmtpSettings> smtpSettings,IServiceProvider serviceProvider )
        {
            _smtpSettings = smtpSettings.Value;
            _serviceProvider = serviceProvider;
        }
        public string GetVerificationEmailTemplate(string fullname, string verificationCode)
        {
            string domain = "medical.pdp-dev.uz";

            return $@"
                          <!DOCTYPE html>
                          <html lang=""en"">
                          <head>
                              <meta charset=""UTF-8"">
                              <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                              <title>Tasdiqlash Kodi</title>
                              <style>
                                  body {{
                                      font-family: Arial, sans-serif;
                                      background-color: #f0f4f8;
                                      margin: 0;
                                      padding: 0;
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      height: 100vh;
                                  }}
                      
                                  .container {{
                                      background-color: #ffffff;
                                      max-width: 500px;
                                      width: 100%;
                                      padding: 30px;
                                      border-radius: 12px;
                                      box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);
                                      text-align: center;
                                  }}
                      
                                  .header h2 {{
                                      font-size: 24px;
                                      color: #333333;
                                      margin-bottom: 20px;
                                  }}
                      
                                  .content p {{
                                      font-size: 16px;
                                      color: #555555;
                                      line-height: 1.6;
                                      margin: 15px 0;
                                  }}
                      
                                  .highlight {{
                                      font-size: 20px;
                                      font-weight: bold;
                                      color: #4361ee;
                                  }}
                      
                                  .footer {{
                                      padding-top: 20px;
                                      border-top: 2px solid #e0e6ed;
                                      margin-top: 20px;
                                      color: #777777;
                                      font-size: 14px;
                                  }}
                      
                                  @media (max-width: 480px) {{
                                      .container {{
                                          padding: 20px;
                                          width: 90%;
                                      }}
                      
                                      .header h2 {{
                                          font-size: 22px;
                                      }}
                      
                                      .content p {{
                                          font-size: 14px;
                                      }}
                      
                                      .highlight {{
                                          font-size: 18px;
                                      }}
                      
                                      .footer {{
                                          font-size: 12px;
                                      }}
                                  }}
                              </style>
                          </head>
                          <body>
                      
                              <div class=""container"">
                                  <div class=""header"">
                                      <h2>Hurmatli, {fullname}</h2>
                                  </div>
                      
                                  <div class=""content"">
                                      <p>Hisobni tasdiqlash kodingiz:</p>

                                      <p><span class=""""highlight"""">{{changepassword(verificationCode)}}</span></p>
                                      <p>Ushbu kodni hechkimga bermang!</p>
                                      <p>Kodning amal qilish muddati 15 daqiqa.</p>
                                  </div>
                      
                                  <div class=""""footer"""">
                                       &copy; {{DateTime.Now.Year.ToString()}} {{domain}}. Barcha huquqlar himoyalangan.
                                  </div>
                              </div>
                      
                          </body>
                          </html>
                ";
        }
        public string GenerateVerificationCode(int length = 6)
        {
            const string chars = "0123456789";
            var random = new Random();
            var code = new char[length];

            for (int i = 0; i < length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            return new string(code);
        }

        public async Task<ApiResult> SendEmailAsync(User user)
        {


            // SMTP Clientni "using" bilan ochish
            using (var smtpClient = new SmtpClient(_smtpSettings.Server)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password),
                EnableSsl = true,
            })
            {
                var code = GenerateVerificationCode(4);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                    Subject = "Email Verification Code",
                    Body = GetVerificationEmailTemplate(user.Name, code),
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(user.Email);

                var verificationRecord = new VerificationCode
                {
                    Email = user.Email,
                    Code = code,
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(15),
                    UserId = user.Id
                };


                await smtpClient.SendMailAsync(mailMessage);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var _redis = scope.ServiceProvider.GetRequiredService<IConnectionMultiplexer>();
                    var db = _redis.GetDatabase();

                    await db.StringSetAsync($"VerificationCode:{user.Email}", JsonConvert.SerializeObject(verificationRecord), DateTime.UtcNow.AddMinutes(15));

                }
            }

            return ApiResult.Success("Parolni tiklash kodi muvaffaqiyatli yuborildi.");

        }
    }


}