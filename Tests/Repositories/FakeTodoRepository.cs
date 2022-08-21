using Domain.Entities;
using Domain.Repositories;

namespace Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {

    }

    public void Update(TodoItem todo)
    {

    }
    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("Titulo Todo", "Tolstoi", DateTime.Now);
    }
}
