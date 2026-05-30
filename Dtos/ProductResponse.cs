namespace ProductsAPI.Dtos;

public record ProductResponse(
    Guid Id,
    string Name,
    decimal Price,
    DateTime CreatedAt
);