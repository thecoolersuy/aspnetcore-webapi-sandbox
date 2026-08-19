namespace AspNetCoreWebApiSandbox;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product newProduct);
    Task<bool> UpdateAsync(int id, Product updatedProduct);
    Task<bool> DeleteAsync(int id);
    Task<bool> DeleteAllAsync();
}