﻿using Airways.Application.Behaviours;
using Airways.Application.MappingProfiles;
using Airways.Application.Services;
using Airways.Application.Services.DevImpl;
using Airways.Application.Services.Impl;
using Airways.Shared.Services;
using Airways.Shared.Services.Impl;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Airways.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));



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
        services.AddScoped<IPersonService, PersonService>();
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
}
