using Microsoft.AspNetCore.Mvc;
using Restaurant.Service.DTOs.Users;
using Restaurant.Service.Interfaces;

namespace Restaurant.Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostUserAsync(UserForCreationDto dto)
            => Ok(await this.userService.CreateAsync(dto));

        [HttpPut("update")]
        public async Task<IActionResult> PutUserAsync(UserForUpdateDto dto)
            => Ok(await this.userService.ChangeAsync(dto));

        [HttpPut("update-password")]
        public async Task<IActionResult> PutPasswordAsync(UserForChangePassword dto)
            => Ok(await this.userService.ChangePasswordAsync(dto));

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteUserAsync(long id)
            => Ok(await this.userService.RemoveAsync(id));

        [HttpGet("get-by-id/{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(await this.userService.RetriewByIdAsync(id));

        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllUser()
            => Ok(await this.userService.RetriewAllAsync());
    }
}
