using Microsoft.EntityFrameworkCore;
using Minimal_API.DataAccess;
using Minimal_API.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("Todolist"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();


app.MapGet("/todoitems", async (TodoDb db) =>
{
    await db.Todos.ToListAsync();
});

app.MapGet("/todoitems/complete", async (TodoDb db) =>
{
    await db.Todos.Where(t => t.IsComplete).ToListAsync();
});

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
{
    _ = await db.Todos.FindAsync(id)
      is ToDo todo ?
      Results.Ok(todo) :
      Results.NotFound();
});

app.MapPost("/todoitems", async (ToDo todo, TodoDb tododb) =>
{
    tododb.Todos.Add(todo);
    await tododb.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, ToDo inputTodo, TodoDb db) =>
{
    var todo=await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    todo.Name=inputTodo.Name;
    todo.IsComplete=inputTodo.IsComplete;
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is ToDo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.Run();

