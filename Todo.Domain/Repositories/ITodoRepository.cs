using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    void Create(TodoItem todo);
    void Update(TodoItem todo);
    TodoItem GetById(Guid id, string user);

    IEnumerable<TodoItem> GetAll(string User);
    IEnumerable<TodoItem> GetAllDone(string User);
    IEnumerable<TodoItem> GetAllUndone(string User);
    IEnumerable<TodoItem> GetByPeriod(string User, DateTime date, bool done);
}
