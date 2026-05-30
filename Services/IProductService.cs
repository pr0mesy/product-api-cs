using ProductsAPI.Dtos;

namespace ProductsAPI.Services;

public interface IProductService
{
    Task<List<ProductResponse>> GetAll();
    Task<ProductResponse> GetById(Guid id);
    Task<ProductResponse> Create(ProductRequest request);
    Task<ProductResponse> Update(Guid id, ProductRequest request);
    Task Delete(Guid id);
}