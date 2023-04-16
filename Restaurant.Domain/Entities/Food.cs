using Restaurant.Domain.Commons;

namespace Restaurant.Domain.Entities;

public class Food : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PriceOfPerPortion { get; set; }
    public int NumberOfPortion { get; set; }

}
