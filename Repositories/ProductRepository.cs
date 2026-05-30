using Microsoft.EntityFrameworkCore;
using ProductsAPI.Config;
using ProductsAPI.Entities;

namespace ProductsAPI.Repositories;

public class ProductRepository : IProductRepository
{
    
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetAll() =>
       await _context.Products.ToListAsync();


    public async Task<Product?> GetById(Guid id) =>
        await _context.Products.FindAsync(id);
    

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task Delete(Guid id)
    {
        var product = await GetById(id);
        if (product is not null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}