using Domain.Commands;

namespace Tests.CommandTests;

public class CreateTodoCommandTests
{
    [Fact]
    [Trait("Category", "Command")]
    public void Dado_um_comando_invalido()
    {
        //Arrange, Act, Assert
        //Red, Greed, Refactor

        var command = new CreateTodoCommand("", "", DateTime.Now);

        command.Validate();

        Assert.False(command.IsValid);
    }

    [Fact]
    [Trait("Category", "Command")]
    public void Dado_um_comando_valido()
    {
        var command = new CreateTodoCommand("Titulo da tarefa", "tolstoi", DateTime.Now);

        command.Validate();

        Assert.True(command.IsValid);
    }
}
