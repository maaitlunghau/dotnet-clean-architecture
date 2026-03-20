using CLEAN_DOMAIN;

namespace CLEAN_APPLICATION;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductAsync(Guid id);
    Task<Product> AddAsync(Product pro);
    Task<Product> UpdateAsync(Product pro);
    Task DeleteAsync(Guid id);
}
