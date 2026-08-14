using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApiSandbox;

public class SqliteProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public SqliteProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product newProduct)
    {

        _context.Products.Add(newProduct);
        _context.SaveChanges();
    }

    public bool Update(int id, Product updatedProduct)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false;
        }
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false;
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteAll()
    {
        var product = GetAll();
        if (product == null)
        {
            return false;
        }
        _context.Products.RemoveRange(product);
        _context.SaveChanges();
        return true;
    }
}