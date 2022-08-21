using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> Todos { get; set; }
    
}
