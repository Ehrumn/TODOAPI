using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context;

public class TodoContext : DbContext
{
	public TodoContext(DbContextOptions<TodoContext> options) 
		: base(options)
	{
	}
	public DbSet<TodoItem> Todos { get; set; }

	protected override void OnModelCreating(ModelBuilder Builder)
	{
		Builder.Entity<TodoItem>().ToTable("Todo");
		Builder.Entity<TodoItem>().Property(x => x.Id);
		Builder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
		Builder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
		Builder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
		Builder.Entity<TodoItem>().Property(x => x.Date);
		Builder.Entity<TodoItem>().HasIndex(b => b.User);
	}
}
