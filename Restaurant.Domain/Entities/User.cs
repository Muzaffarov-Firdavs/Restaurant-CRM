using Restaurant.Domain.Commons;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
