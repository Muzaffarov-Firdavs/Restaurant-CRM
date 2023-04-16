using AutoMapper;
using Restaurant.Data.IRepositories;
using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.SoldFood;
using Restaurant.Service.Exceptions;
using Restaurant.Service.Interfaces;
using System.Linq.Expressions;

namespace Restaurant.Service.Services
{
    public class SoldFoodService : ISoldFoodService
    {
        private readonly IRepository<SoldFood> soldFoodRepository;
        private readonly IMapper mapper;

        public SoldFoodService(IRepository<SoldFood> soldFoodRepository, IMapper mapper)
        {
            this.soldFoodRepository = soldFoodRepository;
            this.mapper = mapper;
        }


        public async Task<SoldFoodForResultDto> ChangeAsync(SoldFoodForUpdateDto dto)
        {
            var updatingSoldFood = await soldFoodRepository.SelectAsync(u => u.Id.Equals(dto.Id));
            if (updatingSoldFood is null)
                throw new CustomException(404, "SoldFood not found");

            this.mapper.Map(dto, updatingSoldFood);
            updatingSoldFood.UpdatedAt = DateTime.UtcNow;
            await this.soldFoodRepository.SaveChangesAsync();
            return mapper.Map<SoldFoodForResultDto>(updatingSoldFood);
        }

        public async Task<SoldFoodForResultDto> CreateAsync(SoldFoodForCreationDto dto)
        {
            var soldFood = await this.soldFoodRepository.SelectAsync(u => u.Name.ToLower() == dto.Name.ToLower());
            if (soldFood is not null)
                throw new CustomException(403, "SoldFood already exsists with email");

            SoldFood mappedFood = mapper.Map<SoldFood>(dto);
            var result = await this.soldFoodRepository.InsertAsync(mappedFood);
            await this.soldFoodRepository.SaveChangesAsync();
            return this.mapper.Map<SoldFoodForResultDto>(result);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var soldfood = await this.soldFoodRepository.SelectAsync(u => u.Id.Equals(id));
            if (soldfood is null)
                throw new CustomException(404, "SoldFood not found");

            await this.soldFoodRepository.DeleteAsync(soldfood);
            await this.soldFoodRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SoldFoodForResultDto>> RetriewAllAsync(
                    Expression<Func<SoldFood, bool>> expression = null, string search = null)
        {
            var soldFoods = soldFoodRepository.SelectAll(expression, isTracking: false);

            var result = mapper.Map<IEnumerable<SoldFoodForResultDto>>(soldFoods);
            if (string.IsNullOrEmpty(search))
            {
                return result.Where(
                    u => u.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return result;
        }

        public async Task<SoldFoodForResultDto> RetriewByIdAsync(long id)
        {
            var soldFood = await soldFoodRepository.SelectAsync(u => u.Id.Equals(id));
            if (soldFood is null)
                throw new CustomException(404, "SoldFood not found");
            return mapper.Map<SoldFoodForResultDto>(soldFood);
        }
    }
}
