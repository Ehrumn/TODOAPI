using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

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
        AddNotifications(new Contract<CreateTodoCommand>()
        .Requires()
        .IsGreaterThan(Title, 3, "Title", "Descreva melhor esta tarefa")
        .IsGreaterThan(User, 5, "User", "Usuário inválido"));
    }
}
