using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.SoldFood;
using System.Linq.Expressions;

namespace Restaurant.Service.Interfaces
{
    public interface ISoldFoodService
    {
        Task<SoldFoodForResultDto> CreateAsync(SoldFoodForCreationDto dto);
        Task<SoldFoodForResultDto> ChangeAsync(SoldFoodForUpdateDto dto);
        Task<SoldFoodForResultDto> RetriewByIdAsync(long id);
        Task<IEnumerable<SoldFoodForResultDto>> RetriewAllAsync(
            Expression<Func<SoldFood, bool>> expression = null, string search = null);
        Task<bool> RemoveAsync(long id);
    }
}
