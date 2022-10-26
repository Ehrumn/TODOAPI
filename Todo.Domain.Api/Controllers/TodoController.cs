using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1/Todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
        )
    {
        command.User = "Rafael";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository
        )
    {
        return repository.GetAll("Rafael");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        [FromServices] ITodoRepository repository
        )
    {
        return repository.GetAllDone("Rafael");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneByPeriod(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Rafael", DateTime.Now.Date, true);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Rafael", DateTime.Now.Date.AddDays(1), true);
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
    {
        return repository.GetAllUndone("Rafael");
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneByPeriod(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Rafael", DateTime.Now.Date, false);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Rafael", DateTime.Now.Date.AddDays(1), false);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody]UpdateTodoCommand command,
        [FromServices]TodoHandler handler)
    {
        command.User = "Rafael";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("MarkAsDone")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
        [FromBody]MarkToDoAsDoneCommand command,
        [FromServices]TodoHandler handler)
    {
        command.User = "Rafael";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("MarkAsUndone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
        [FromBody]MarkTodoAsUndoneCommand command,
        [FromServices]TodoHandler handler)
    {
        command.User = "Rafael";
        return (GenericCommandResult)handler.Handle(command);
    }
}
