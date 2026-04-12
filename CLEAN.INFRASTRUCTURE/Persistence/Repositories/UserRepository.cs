using CLEAN.DOMAIN.Entities;
using CLEAN.DOMAIN.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CLEAN.INFRASTRUCTURE.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
