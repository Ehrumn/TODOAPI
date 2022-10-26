using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Context;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context.Todos.AsNoTracking().FirstOrDefault(TodoQueries.GetById(id, user));
        }

        public IEnumerable<TodoItem> GetAll(string User)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(User)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string User) => _context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(User)).OrderBy(x => x.Date);

        public IEnumerable<TodoItem> GetAllUndone(string User) => _context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(User)).OrderBy(x => x.Date);

        public IEnumerable<TodoItem> GetByPeriod(string User, DateTime date, bool done) => _context.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(User, date, done)).OrderBy(x => x.Date);
    }
}
