namespace AspNetCoreWebApiSandbox;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product{Id=1, Name="Nokia", Price= 100.2m},
        new Product{Id=2, Name="Iphone", Price = 23000m},
        new Product{Id=3, Name="Nothing Phone", Price = 40000m},
    };

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
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
        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false;
        }
        _products.Remove(product);
        return true;

    }
    public bool DeleteAll()
    {
        var product = GetAll();
        if (product == null)
        {
            return false;
        }
        _products.Clear();
        return true;

    }

}