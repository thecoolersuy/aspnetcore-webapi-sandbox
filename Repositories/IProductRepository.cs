namespace AspNetCoreWebApiSandbox;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(int id);
    void Add(Product newProduct);
    void Update(int id, Product updatedProduct);
    void Delete(int id);
}