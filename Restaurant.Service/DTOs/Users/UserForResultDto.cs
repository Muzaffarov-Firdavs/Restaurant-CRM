using System.ComponentModel.DataAnnotations;

namespace Restaurant.Service.DTOs.Users
{
    public class UserForResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
