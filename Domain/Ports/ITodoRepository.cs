using PatternCQRS.Domain.Entities;

namespace PatternCQRS.Domain.Ports;

public interface ITodoRepository
{
    System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TodoItem>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task AddAsync(TodoItem item, System.Threading.CancellationToken cancellationToken = default);
}
