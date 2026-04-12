namespace CLEAN.APPLICATION.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(Guid id);
    Task<UserDto> CreateAsync(CreateUserDto request);
    Task UpdateAsync(Guid id, UpdateUserDto request);
    Task DeleteAsync(Guid id);
}
