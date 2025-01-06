using Airways.Application.Common.Email;
using Airways.Application.MappingProfiles;
using Airways.Application.Services;
using Airways.Application.Services.DevImpl;
using Airways.Application.Services.Impl;
using Airways.Shared.Services;
using Airways.Shared.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Airways.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            services.RegisterCashing();

            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IAircraftService, AicraftService>();
            services.AddScoped<IAirlineService, AirlineService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPricePolicyService, PricePolicyService>();
            services.AddScoped<IReviewservice, ReviewService>();
            services.AddScoped<IReysService, ReysService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IClaimService, ClaimService>();


            if (env.IsDevelopment())
                services.AddScoped<IEmailService, DevEmailService>();
            else
                services.AddScoped<IEmailService, EmailService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }

        private static void RegisterCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }

        public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
        }
    }

}
