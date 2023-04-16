using System.ComponentModel.DataAnnotations;

namespace Restaurant.Service.DTOs.Users
{
    public class UserForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
