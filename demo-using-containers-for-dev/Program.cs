using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("todos") ?? throw new Exception("Need a Connection String");

builder.Services.AddDbContext<TodosDataContext>(options =>
{
    options.UseNpgsql(connectionString);
});


var app = builder.Build();

app.MapGet("/todos", async (TodosDataContext context) =>
{

    var embedded = await context.Todos.Select(t => new TodoItemResponse(t.Id.ToString(), t.Description, t.Completed)).ToListAsync();

    return Results.Ok(new { embedded });
});

app.MapPost("/todos", async (TodosDataContext context, TodoItemRequest request) =>
{

    var todo = new TodoEntity { Description = request.Description, Completed = false };
    context.Todos.Add(todo);
    await context.SaveChangesAsync();

    var response = new TodoItemResponse(todo.Id.ToString(), todo.Description, todo.Completed);
    return Results.Ok(response);
});

app.Run();



public class TodoEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; } = false;
}

public class TodosDataContext : DbContext
{
    public TodosDataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoEntity> Todos { get; set; }
}

public record TodoItemResponse(string Id, string Description, bool Completed);

public record TodoItemRequest(string Description);