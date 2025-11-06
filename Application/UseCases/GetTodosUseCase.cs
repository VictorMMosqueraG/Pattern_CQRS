using PatternCQRS.Application.DTOs;
using PatternCQRS.Domain.Ports;
using System.Linq;

namespace PatternCQRS.Application.UseCases;

public sealed class GetTodosUseCase
{
    private readonly ITodoRepository _repository;

    public GetTodosUseCase(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TodoDto>> HandleAsync(System.Threading.CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetAllAsync(cancellationToken);
        return items.Select(i => new TodoDto(i.Id, i.Title, i.Done));
    }
}
