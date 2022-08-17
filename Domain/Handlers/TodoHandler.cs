using Domain.Commands;
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

    }
}
