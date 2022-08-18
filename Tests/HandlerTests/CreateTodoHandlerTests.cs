using Domain.Commands;
using Domain.Handlers;

namespace Tests.HandlerTests;

public class CreateTodoHandlerTests
{

    [Fact]
    [Trait("Category", "Handler")]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        var command = new CreateTodoCommand("", "", DateTime.Now);
        var handler = new TodoHandler(null);

        Assert.False(true);
    }

    [Fact]
    [Trait("Category", "Handler")]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        Assert.False(true);
    }
}
