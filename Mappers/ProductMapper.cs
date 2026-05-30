using ProductsAPI.Dtos;
using ProductsAPI.Entities;

namespace ProductsAPI.Mappers;

public static class ProductMapper
{
    public static ProductResponse ToResponse(Product product) =>
        new(product.Id,
            product.Name,
            product.Price,
            product.CreatedAt);

    public static Product ToEntity(ProductRequest request) =>
        new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            CreatedAt = DateTime.UtcNow
        };

    public static void UpdateEntity(Product product, ProductRequest request)
    {
        product.Name = request.Name;
        product.Price = request.Price;
    }
}