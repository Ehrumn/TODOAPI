using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class MarkTodoAsUndone : Notifiable<Notification>, ICommand
{
    public MarkTodoAsUndone() { }
    public MarkTodoAsUndone(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<CreateTodoCommand>()
        .Requires()
        .IsLowerThan(User, 6, "User", "Usuário inválido"));
    }
}
