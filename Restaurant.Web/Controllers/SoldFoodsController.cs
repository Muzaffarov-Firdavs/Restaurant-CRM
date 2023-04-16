using Microsoft.AspNetCore.Mvc;
using Restaurant.Service.DTOs.SoldFood;
using Restaurant.Service.Interfaces;

namespace Restaurant.Web.Controllers
{
    public class SoldFoodsController : BaseController
    {
        private readonly ISoldFoodService soldFoodService;

        public SoldFoodsController(ISoldFoodService soldFoodService)
        {
            this.soldFoodService = soldFoodService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> PostUserAsync(SoldFoodForCreationDto dto)
            => Ok(await this.soldFoodService.CreateAsync(dto));

        [HttpPut("update")]
        public async Task<IActionResult> PutUserAsync(SoldFoodForUpdateDto dto)
            => Ok(await this.soldFoodService.ChangeAsync(dto));

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteUserAsync(long id)
            => Ok(await this.soldFoodService.RemoveAsync(id));

        [HttpGet("get-by-id/{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(await this.soldFoodService.RetriewByIdAsync(id));

        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllUser()
            => Ok(await this.soldFoodService.RetriewAllAsync());
    }
}
