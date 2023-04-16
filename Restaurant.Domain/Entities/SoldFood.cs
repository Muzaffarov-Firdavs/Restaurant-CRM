using Restaurant.Domain.Commons;

namespace Restaurant.Domain.Entities;

public class SoldFood : Auditable
{
    public string Name { get; set; }
    public int Portion { get; set; }
    public decimal Price { get; set; }
}
