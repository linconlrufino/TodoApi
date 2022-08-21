using Domain.Commands;
using Domain.Handlers;
using Tests.Repositories;

namespace Tests.HandlerTests;

public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand invalidTodoCommand;
    private readonly CreateTodoCommand validTodoCommand;
    private readonly TodoHandler handler;
    private GenericCommandResult result;

    public CreateTodoHandlerTests()
    {
        invalidTodoCommand = new CreateTodoCommand("", "", DateTime.Now);
        validTodoCommand = new CreateTodoCommand("Titulo da tarefa", "tolstoi", DateTime.Now);
        handler = new TodoHandler(new FakeTodoRepository());
        result = new GenericCommandResult();
    }

    [Fact]
    [Trait("Category", "Handler")]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        result = (GenericCommandResult)handler.Handle(invalidTodoCommand);

        Assert.False(result.Success);
    }

    [Fact]
    [Trait("Category", "Handler")]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        result = (GenericCommandResult)handler.Handle(validTodoCommand);

        Assert.True(result.Success);
    }
}