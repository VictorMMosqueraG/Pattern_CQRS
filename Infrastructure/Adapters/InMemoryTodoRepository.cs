using PatternCQRS.Domain.Entities;
using PatternCQRS.Domain.Ports;

namespace PatternCQRS.Infrastructure.Adapters;

public sealed class InMemoryTodoRepository : ITodoRepository
{
    private readonly System.Collections.Generic.List<TodoItem> _items = new()
    {
        new TodoItem(System.Guid.NewGuid(), "Example todo 1", false),
        new TodoItem(System.Guid.NewGuid(), "Example todo 2", true)
    };

    public System.Threading.Tasks.Task AddAsync(TodoItem item, System.Threading.CancellationToken cancellationToken = default)
    {
        _items.Add(item);
        return System.Threading.Tasks.Task.CompletedTask;
    }

    public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TodoItem>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default)
    {
        return System.Threading.Tasks.Task.FromResult<System.Collections.Generic.IEnumerable<TodoItem>>(_items);
    }
}
