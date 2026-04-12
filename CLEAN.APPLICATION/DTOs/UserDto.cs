namespace CLEAN.APPLICATION;

public record UserDto(Guid Id, string Username, string Email, int Age);
public record CreateUserDto(string Username, string Email, int Age);
public record UpdateUserDto(string? Username, string? Email, int? Age);