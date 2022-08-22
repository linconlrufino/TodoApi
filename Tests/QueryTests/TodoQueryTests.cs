
using Domain.Entities;
using Domain.Queries;
using System.Linq;

namespace Tests.QueryTests;

public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();

        _items.Add(new TodoItem("Tarefa 1", "UsuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "UsuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "Tolstoi", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "UsuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "Tolstoi", DateTime.Now));
    }

    [Fact]
    [Trait("Category", "Query")]
    public void Deve_retornar_tarefas_apenas_do_usuario()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("Tolstoi"));

        Assert.Equal(2, result.Count());
    }
}
