using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.Foods;
using System.Linq.Expressions;

namespace Restaurant.Service.Interfaces
{
    public interface IFoodService
    {
        Task<FoodForResultDto> CreateAsync(FoodForCreationDto dto);
        Task<FoodForResultDto> ChangeAsync(FoodForUpdateDto dto);
        Task<FoodForResultDto> RetriewByIdAsync(long id);
        Task<IEnumerable<FoodForResultDto>> RetriewAllAsync(
            Expression<Func<Food, bool>> expression = null, string search = null);
        Task<bool> RemoveAsync(long id);
    }
}
