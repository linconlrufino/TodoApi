using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Contexts;
public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
{
    public TodoContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Todos;User Id=sa;Password=271198brL@!");

        return new TodoContext(optionsBuilder.Options);
    }
}
