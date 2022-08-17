using Domain.Commands;

namespace Tests.CommandTests;

public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand invalidTodoCommand;
    private readonly CreateTodoCommand validTodoCommand;

    public CreateTodoCommandTests()
    {
        invalidTodoCommand = new CreateTodoCommand("", "", DateTime.Now);
        validTodoCommand = new CreateTodoCommand("Titulo da tarefa", "tolstoi", DateTime.Now);
    }

    [Fact]
    [Trait("Category", "Command")]
    public void Dado_um_comando_invalido()
    {
        //Arrange, Act, Assert
        //Red, Greed, Refactor

        invalidTodoCommand.Validate();

        Assert.False(invalidTodoCommand.IsValid);
    }

    [Fact]
    [Trait("Category", "Command")]
    public void Dado_um_comando_valido()
    {
        validTodoCommand.Validate();

        Assert.True(validTodoCommand.IsValid);
    }
}
