using Flunt.Notifications;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers;

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
        throw new NotImplementedException();
    }
}
