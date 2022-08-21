using Domain.Entities;

namespace Tests.EntityTests;

public class TodoItemTests
{
    private readonly TodoItem validTodo;

    public TodoItemTests()
    {
        validTodo = new TodoItem("Titulo Aqui", "tolstoi", DateTime.Now);
    }

    [Fact]
    [Trait("Category", "Entity")]
    public void Dado_um_novo_todo_nao_pode_ser_concluido()
    {
        Assert.False(validTodo.Done);
    }
}
