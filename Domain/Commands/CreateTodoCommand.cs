using Flunt.Notifications;
using Flunt.Validations;
using Shared.Commands;

namespace Domain.Commands;

public class CreateTodoCommand : Notifiable<Notification>, ICommand
{

    public CreateTodoCommand() { }

    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Title, 3, "Title", "Por favor , descreva melhor esta tarefa!")
                .IsGreaterThan(User, 6, "User", "Usuário inválido")
        );
    }
}
