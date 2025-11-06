namespace PatternCQRS.Domain.Entities;

public sealed record TodoItem(System.Guid Id, string Title, bool Done);
