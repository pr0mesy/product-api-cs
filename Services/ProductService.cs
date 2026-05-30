using ProductsAPI.Dtos;
using ProductsAPI.Exceptions;
using ProductsAPI.Mappers;
using ProductsAPI.Repositories;

namespace ProductsAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductResponse>> GetAll() =>
        (await _repository.GetAll())
        .Select(ProductMapper.ToResponse)
        .ToList();

    public async Task<ProductResponse> GetById(Guid id)
    {
        var product = await _repository.GetById(id);

        if (product is null)
            throw new ProductNotFoundException(id);

        return ProductMapper.ToResponse(product);
    }

    public async Task<ProductResponse> Create(ProductRequest request)
    {
        var product = ProductMapper.ToEntity(request);
        var created = await _repository.Create(product);
        return ProductMapper.ToResponse(created);
    }

    public async Task<ProductResponse> Update(Guid id, ProductRequest request)
    {
        var product = await _repository.GetById(id);

        if (product is null)
            throw new ProductNotFoundException(id);

        ProductMapper.UpdateEntity(product, request);
        var updated = await _repository.Update(product);
        return ProductMapper.ToResponse(updated);
    }

    public async Task Delete(Guid id)
    {
        var product = await _repository.GetById(id);

        if (product is null)
            throw new ProductNotFoundException(id);

        await _repository.Delete(id);
    }
}