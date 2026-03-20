using CLEAN_DOMAIN;
using Microsoft.EntityFrameworkCore;

namespace CLEAN_INTERFACE;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
