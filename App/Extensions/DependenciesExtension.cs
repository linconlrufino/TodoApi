using Domain.Handlers;
using Domain.Repositories;
using Infra.Contexts;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public static void AddServices(this IServiceCollection services)
    {
    }

    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<TodoHandler, TodoHandler>();
    }
}
