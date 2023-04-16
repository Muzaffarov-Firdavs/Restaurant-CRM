using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.Users;
using System.Linq.Expressions;

namespace Restaurant.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
        Task<UserForResultDto> ChangeAsync(UserForUpdateDto dto);
        Task<UserForResultDto> ChangePasswordAsync(UserForChangePassword dto);
        Task<UserForResultDto> RetriewByIdAsync(long id);
        Task<IEnumerable<UserForResultDto>> RetriewAllAsync(
            Expression<Func<User, bool>> expression = null, string search = null);
        Task<bool> RemoveAsync(long id);

    }
}
