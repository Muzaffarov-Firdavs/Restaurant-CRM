using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.TeleTrust;
using Restaurant.Service.DTOs.Users;
using Restaurant.Service.Helpers;

namespace Restaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailVerification emailVerification;

        public EmailController(EmailVerification emailVerification)
        {
            this.emailVerification = emailVerification;
        }

        [HttpPost]
        public async Task<IActionResult> SendVerificationCode(UserForResultDto user)
        {
            var result = await this.emailVerification.SendAsync(user);
            return Ok(result);
        }

    }
}
