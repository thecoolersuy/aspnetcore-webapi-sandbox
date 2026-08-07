namespace AspNetCoreWebApiSandbox;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(int id);
    void Add(Product newProduct);
    bool Update(int id, Product updatedProduct);
    bool Delete(int id);
}