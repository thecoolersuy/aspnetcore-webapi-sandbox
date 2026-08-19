using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiSandbox;

public class SqliteProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public SqliteProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product newProduct)
    {

        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(int id, Product updatedProduct)
    {
        var product = await GetByIdAsync(id);
        if (product == null)
        {
            return false;
        }
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product == null)
        {
            return false;
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllAsync()
    {
        var product = await GetAllAsync();
        if (product == null)
        {
            return false;
        }
        _context.Products.RemoveRange(product);
        await _context.SaveChangesAsync();
        return true;
    }
}