using CLEAN.DOMAIN.Common;

namespace CLEAN.DOMAIN.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
}
