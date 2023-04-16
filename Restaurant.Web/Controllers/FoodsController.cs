using Microsoft.AspNetCore.Mvc;
using Restaurant.Service.DTOs.Foods;
using Restaurant.Service.Interfaces;

namespace Restaurant.Web.Controllers
{
    public class FoodsController : BaseController
    {
        private readonly IFoodService foodService;
        public FoodsController(IFoodService foodService)
        {
            this.foodService = foodService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> PostUserAsync(FoodForCreationDto dto)
            => Ok(await this.foodService.CreateAsync(dto));

        [HttpPut("update")]
        public async Task<IActionResult> PutUserAsync(FoodForUpdateDto dto)
            => Ok(await this.foodService.ChangeAsync(dto));

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteUserAsync(long id)
            => Ok(await this.foodService.RemoveAsync(id));

        [HttpGet("get-by-id/{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(await this.foodService.RetriewByIdAsync(id));

        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllUser()
            => Ok(await this.foodService.RetriewAllAsync());
    }
}
