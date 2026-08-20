using AspNetCoreWebApiSandbox;

namespace AspNetCoreWebApiSandbox.Test;

public class FakeProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product {Id = 1,Name= "Test IPhone", Price = 999},
        new Product {Id = 2,Name= "Test NOTHING", Price = 299}
    };

    public Task<List<Product>> GetAllAsync() => Task.FromResult(_products);

    public Task<Product?> GetByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task AddAsync(Product newProduct)
    {
        newProduct.Id = _products.Count + 1;
        _products.Add(newProduct);
        return Task.CompletedTask;
    }

    public Task<bool> UpdateAsync(int id, Product updatedProduct)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return Task.FromResult(false);
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return Task.FromResult(false);
        _products.Remove(product);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAllAsync()
    {
        var product = _products;
        if (product == null)
        {
            Task.FromResult(false);
        }
        _products.Clear();
        return Task.FromResult(true);
    }
}