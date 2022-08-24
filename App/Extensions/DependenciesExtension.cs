using Domain.Handlers;
using Domain.Repositories;
using Infra.Contexts;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace App.Extensions;

public static class DependenciesExtension
{
    public static void AddSqlConnection(this IServiceCollection services, string connectString)
    {
        services.AddDbContext<TodoContext>(option => option.UseSqlServer(connectString));
    }

    public static void AddInMemoryDataBaseConnection(this IServiceCollection services, string connectString)
    {
        services.AddDbContext<TodoContext>(option => option.UseInMemoryDatabase(connectString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ITodoRepository, TodoRepository>();
    }

    public static void AddServices(this IServiceCollection services) { }

    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<TodoHandler, TodoHandler>();
    }

    public static void AddAuthenticationJwt(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://securetoken.google.com/todoapp-2cd1f";
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = "https://securetoken.google.com/todoapp-2cd1f",
                       ValidateAudience = true,
                       ValidAudience = "todoapp-2cd1f",
                       ValidateLifetime = true
                   };
               });
    }
}