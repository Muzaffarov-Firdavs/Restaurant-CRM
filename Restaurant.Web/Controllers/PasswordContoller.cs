using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Service.DTOs.Users;
using Restaurant.Service.Helpers;

namespace Restaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordContoller : ControllerBase
    {
        private readonly PasswordHasher passwordHasher;

        public PasswordContoller(PasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }


        [HttpGet]
        public async Task<IActionResult> HashPassword(string password)
        {
            var result = this.passwordHasher.Hash(password);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> VerifyPassword(string password, string salt, string passwordHash)
        {
            var result = this.passwordHasher.Verify(password, salt, passwordHash);
            return Ok(result);
        }
    }
}
