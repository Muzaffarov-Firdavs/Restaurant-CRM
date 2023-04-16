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
                throw new CustomException(404, "Food not found");

            this.mapper.Map(dto, updatingFood);
            updatingFood.UpdatedAt = DateTime.UtcNow;
            await this.foodRepository.SaveChangesAsync();
            return mapper.Map<FoodForResultDto>(updatingFood);
        }

        public async Task<FoodForResultDto> CreateAsync(FoodForCreationDto dto)
        {
            var food = await this.foodRepository.SelectAsync(u => u.Name.ToLower() == dto.Name.ToLower());
            if (food is not null)
                throw new CustomException(403, "Food already exsists with email");

            Food mappedFood = mapper.Map<Food>(dto);
            var result = await this.foodRepository.InsertAsync(mappedFood);
            await this.foodRepository.SaveChangesAsync();
            return this.mapper.Map<FoodForResultDto>(result);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var food = await this.foodRepository.SelectAsync(u => u.Id.Equals(id));
            if (food is null)
                throw new CustomException(404, "Food not found");

            await this.foodRepository.DeleteAsync(food);
            await this.foodRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FoodForResultDto>> RetriewAllAsync(
                Expression<Func<Food, bool>> expression = null, string search = null)
        {
            var foods = foodRepository.SelectAll(expression, isTracking: false);

            var result = mapper.Map<IEnumerable<FoodForResultDto>>(foods);
            if (string.IsNullOrEmpty(search))
            {
                return result.Where(
                    u => u.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return result;
        }

        public async Task<FoodForResultDto> RetriewByIdAsync(long id)
        {
            var food = await foodRepository.SelectAsync(u => u.Id.Equals(id));
            if (food is null)
                throw new CustomException(404, "Food not found");
            return mapper.Map<FoodForResultDto>(food);
        }
    }
}
