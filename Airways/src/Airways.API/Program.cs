using Airways.API;
using Airways.API.Filters;
using Airways.API.Middleware;
using Airways.Application;
using Airways.DataAccess;
using Airways.DataAccess.Authentication;
using Airways.DataAccess.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

builder.Services.AddSwaggerGen();

builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddJwt(builder.Configuration);
builder.Services.AddHttpContextAccessor();



var app = builder.Build();

using var scope = app.Services.CreateScope();
await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airways"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlerMiddlewear>();

app.MapControllers();

app.Run();

namespace Airways.API
{
    public partial class Program { }
}
