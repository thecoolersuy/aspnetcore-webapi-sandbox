namespace AspNetCoreWebApiSandbox;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product{Id=1, Name="Nokia", Price= 100.2m},
        new Product{Id=2, Name="Iphone", Price = 23000m},
        new Product{Id=3, Name="Nothing Phone", Price = 40000m},
    };

    public Task<List<Product>> GetAllAsync() => Task.FromResult(_products.ToList());

    public Task<Product?> GetByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task AddAsync(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
        return Task.CompletedTask;

    }

    public Task<bool> UpdateAsync(int id, Product updatedProduct)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return Task.FromResult(false);
        }
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return Task.FromResult(false);
        }
        _products.Remove(product);
        return Task.FromResult(true);

    }
    public Task<bool> DeleteAllAsync()
    {
        var product = _products.ToList();
        if (product == null)
        {
            return Task.FromResult(false);
        }
        _products.Clear();
        return Task.FromResult(true);

    }

}