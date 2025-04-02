using Microsoft.EntityFrameworkCore;
using Minimal_API.Model;

namespace Minimal_API.DataAccess
{
    public class TodoDb :DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<ToDo> Todos => Set<ToDo>();
    }
}
