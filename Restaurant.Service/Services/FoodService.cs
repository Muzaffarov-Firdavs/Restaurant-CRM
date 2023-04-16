using AutoMapper;
using Restaurant.Data.IRepositories;
using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.Foods;
using Restaurant.Service.DTOs.Users;
using Restaurant.Service.Exceptions;
using Restaurant.Service.Interfaces;
using System.Linq.Expressions;

namespace Restaurant.Service.Services
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> foodRepository;
        private readonly IMapper mapper;

        public FoodService(IRepository<Food> foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        public async Task<FoodForResultDto> ChangeAsync(FoodForUpdateDto dto)
        {
            var updatingFood = await foodRepository.SelectAsync(u => u.Id.Equals(dto.Id));
            if (updatingFood is null)
                throw new CustomException(404, "User not found");

            this.mapper.Map(dto, updatingFood);
            updatingFood.UpdatedAt = DateTime.UtcNow;
            await this.foodRepository.SaveChangesAsync();
            return mapper.Map<FoodForResultDto>(updatingFood);
        }

        public Task<FoodForResultDto> CreateAsync(FoodForCreationDto dto)
        {

        }

        public Task<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FoodForResultDto>> RetriewAllAsync(Expression<Func<Food, bool>> expression = null, string search = null)
        {
            throw new NotImplementedException();
        }

        public Task<FoodForResultDto> RetriewByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
