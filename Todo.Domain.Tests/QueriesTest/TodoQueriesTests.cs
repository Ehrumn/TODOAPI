using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTest
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa1", DateTime.Now, "Usuario A"));
            _items.Add(new TodoItem("Tarefa2", DateTime.Now, "Rafael"));
            _items.Add(new TodoItem("Tarefa3", DateTime.Now, "Usuario b"));
            _items.Add(new TodoItem("Tarefa4", DateTime.Now, "Rafael"));
            _items.Add(new TodoItem("Tarefa5", DateTime.Now, "Usuario c"));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_Rafael()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Rafael"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
