using CLEAN_APPLICATION;
using CLEAN_DOMAIN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CLEAN_INTERFACE.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _dbContext;
    public ProductRepository(DataContext dbContext)
        => _dbContext = dbContext;


    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<Product> AddAsync(Product pro)
    {
        await _dbContext.Products.AddAsync(pro);
        await _dbContext.SaveChangesAsync();

        return pro;
    }

    public async Task<Product> UpdateAsync(Product pro)
    {
        _dbContext.Products.Update(pro);
        await _dbContext.SaveChangesAsync();

        return pro;
    }

    public async Task DeleteAsync(Guid id)
    {
        var pro = _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (pro is not null)
        {
            _dbContext.Remove(pro);
            await _dbContext.SaveChangesAsync();
        }
    }
}
