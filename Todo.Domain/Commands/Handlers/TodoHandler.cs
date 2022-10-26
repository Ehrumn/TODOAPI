using Flunt.Notifications;
using System.Net.Http.Headers;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkToDoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        //Criar um Todo
        var todo = new TodoItem(command.Title, command.Date, command.User);

        //Salvar um todo no banco
        _repository.Create(todo);

        return new GenericCommandResult(true, "Sucesso", todo);

    }
    public ICommandResult Handle(UpdateTodoCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        //Recuperar o TodoItem
        var todo = _repository.GetById(command.Id, command.User);

        //Salva no banco
        todo.UpdateTitle(command.Title);

        //Salva no banco
        _repository.Update(todo);

        return new GenericCommandResult(true, "Sucesso", todo);

    }
    public ICommandResult Handle(MarkToDoAsDoneCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        //Recuperar o TodoItem
        var todo = _repository.GetById(command.Id, command.User);

        //Altera o estado
        todo.MarkAsDone(); 
        
        //Salva no banco
        _repository.Update(todo);

        return new GenericCommandResult(true, "Sucesso", todo);
    }
    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        //Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        //Recuperar o TodoItem
        var todo = _repository.GetById(command.Id, command.User);

        //Altera o estado
        todo.MarkAsUndone();

        //Salva no banco
        _repository.Update(todo);

        return new GenericCommandResult(true, "Sucesso", todo);
    }
}
