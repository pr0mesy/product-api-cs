using ProductsAPI.Entities;

namespace ProductsAPI.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product?> GetById(Guid id);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task Delete(Guid id);
}