using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Flunt.Notifications;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        var todo = new TodoItem(command.Title, command.User, command.Date);

        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }
}