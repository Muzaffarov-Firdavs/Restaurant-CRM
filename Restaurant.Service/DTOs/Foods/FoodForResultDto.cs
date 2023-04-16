namespace Restaurant.Service.DTOs.Foods
{
    public class FoodForResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceOfPerPortion { get; set; }
        public int NumberOfPortion { get; set; }
    }
}
