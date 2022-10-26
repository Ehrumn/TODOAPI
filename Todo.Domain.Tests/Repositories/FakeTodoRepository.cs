using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
        
    }

    public void Update(TodoItem todo)
    {
        
    }

    public IEnumerable<TodoItem> GetAll(string User)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string User)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUndone(string User)
    {
        throw new NotImplementedException();
    }

    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("Titulo aqui", DateTime.Now, user);
    }

    public IEnumerable<TodoItem> GetByPeriod(string User, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }

}
