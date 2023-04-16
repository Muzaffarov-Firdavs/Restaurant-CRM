using System.ComponentModel.DataAnnotations;

namespace Restaurant.Service.DTOs.Foods
{
    public class FoodForUpdateDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceOfPerPortion { get; set; }
        public int NumberOfPortion { get; set; }
    }
}
