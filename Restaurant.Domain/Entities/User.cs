using Restaurant.Domain.Commons;

namespace Restaurant.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}
