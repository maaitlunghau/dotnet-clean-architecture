using CLEAN.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace CLEAN.INFRASTRUCTURE.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
}
