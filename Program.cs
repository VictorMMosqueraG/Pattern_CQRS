var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PatternCQRS.Domain.Ports.ITodoRepository, PatternCQRS.Infrastructure.Adapters.InMemoryTodoRepository>();
builder.Services.AddScoped<PatternCQRS.Application.UseCases.GetTodosUseCase>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todos", async (PatternCQRS.Application.UseCases.GetTodosUseCase useCase) =>
{
	var todos = await useCase.HandleAsync();
	return Results.Ok(todos);
});

app.Run();
