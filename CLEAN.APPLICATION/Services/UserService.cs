using CLEAN.APPLICATION.Interfaces;
using CLEAN.DOMAIN.Entities;
using CLEAN.DOMAIN.Interfaces;

namespace CLEAN.APPLICATION.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(user => new UserDto(
            user.Id,
            user.Username,
            user.Email,
            user.Age
        ));
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto(user.Id, user.Username, user.Email, user.Age);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto request)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            Age = request.Age,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);

        return new UserDto(user.Id, user.Username, user.Email, user.Age);
    }

    public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto request)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) throw new Exception("User not found");

        user.Username = request.Username!;
        user.Email = request.Email!;
        user.Age = request.Age!.Value;

        await _userRepository.UpdateAsync(user);

        return new UserDto(user.Id, user.Username, user.Email, user.Age);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) throw new Exception("User not found");

        await _userRepository.DeleteAsync(id);
    }
}
