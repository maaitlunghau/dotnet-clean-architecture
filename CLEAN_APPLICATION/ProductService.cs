using CLEAN_DOMAIN;

namespace CLEAN_APPLICATION;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
        => _productRepository = productRepository;

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task<Product?> GetOneProduct(Guid id)
    {
        return await _productRepository.GetProductAsync(id);
    }

    public async Task AddProduct(Product pro)
    {
        await _productRepository.AddAsync(pro);
    }

    public async Task UpdateProduct(Product pro)
    {
        await _productRepository.UpdateAsync(pro);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}
