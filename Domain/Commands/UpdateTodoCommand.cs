using Flunt.Notifications;
using Flunt.Validations;
using Shared.Commands;

namespace Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand() { }

    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(User, 6, "User", "Usuário inválido!")
                .IsGreaterThan(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
            );
    }
}