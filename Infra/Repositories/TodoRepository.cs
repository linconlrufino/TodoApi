using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public void Create(TodoItem todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }
    public void Update(TodoItem todo)
    {
        _context.Update(todo);
        _context.SaveChanges();
    }

    public TodoItem GetById(Guid id, string user)
    {
        return _context.Todos
                     .AsNoTracking()
                     .FirstOrDefault(TodoQueries.GetById(id, user));
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _context.Todos
                    .AsNoTracking()
                    .Where(TodoQueries.GetAll(user))
                    .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _context.Todos
                    .AsNoTracking()
                    .Where(TodoQueries.GetAllUndone(user))
                    .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos
                   .AsNoTracking()
                   .Where(TodoQueries.GetByPeriod(user, date, done))
                   .OrderBy(x => x.Date);
    }
}
