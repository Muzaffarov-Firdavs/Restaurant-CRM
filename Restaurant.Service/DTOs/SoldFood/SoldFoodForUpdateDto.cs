using System.ComponentModel.DataAnnotations;

namespace Restaurant.Service.DTOs.SoldFood
{
    public class SoldFoodForUpdateDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Portion { get; set; }
        public decimal Price { get; set; }
    }
}
