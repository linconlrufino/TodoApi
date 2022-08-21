using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Flunt.Notifications;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        //Fast Fail Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        //Recuperando o Todo do banco - Reidratação
        TodoItem todo = _repository.GetById(command.Id, command.User);

        //Altera o titulo
        todo.UpdateTitle(command.Title);

        //Atualiza no banco
        _repository.Update(todo);

        //retorna o resultado
        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }
}