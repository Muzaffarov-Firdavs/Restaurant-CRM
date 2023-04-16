using System.ComponentModel.DataAnnotations;

namespace Restaurant.Service.DTOs.Users
{
    public class UserForUpdateDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
