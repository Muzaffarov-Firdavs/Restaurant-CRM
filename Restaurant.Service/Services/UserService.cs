using AutoMapper;
using Restaurant.Data.IRepositories;
using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.Users;
using Restaurant.Service.Exceptions;
using Restaurant.Service.Helpers;
using Restaurant.Service.Interfaces;
using System.Linq.Expressions;

namespace Restaurant.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserForResultDto> ChangeAsync(UserForUpdateDto dto)
        {
            var updatingUser = await userRepository.SelectAsync(u => u.Id.Equals(dto.Id));
            if (updatingUser is null)
                throw new CustomException(404, "User not found");

            var hash = PasswordHasher.Hash(dto.Password);
            if (PasswordHasher.Verify(dto.Password, hash.passwordHash, hash.salt))
                throw new Exception("Existing Password is incorrect");

            this.mapper.Map(dto, updatingUser);
            updatingUser.UpdatedAt = DateTime.UtcNow;
            await this.userRepository.SaveChangesAsync();
            return mapper.Map<UserForResultDto>(updatingUser);
        }

        public async Task<UserForResultDto> ChangePasswordAsync(UserForChangePassword dto)
        {
            User existUser = await userRepository.SelectAsync(u => u.Email == dto.Email);
            if (existUser is null)
                throw new Exception("This username is not exist");

            var hash = PasswordHasher.Hash(dto.OldPassword);
            if (PasswordHasher.Verify(dto.NewPassword, hash.passwordHash, existUser.Salt))
                throw new Exception("Existing Password is incorrect");
            else if (dto.NewPassword != dto.ComfirmPassword)
                throw new Exception("New password and confirm password are not equal");
            else if (existUser.Password != dto.OldPassword)
                throw new Exception("Password is incorrect");

            existUser.Password = dto.ComfirmPassword;
            await userRepository.SaveChangesAsync();
            return mapper.Map<UserForResultDto>(existUser);
        }

        public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
        {
            User user = await this.userRepository.SelectAsync(u => u.Email.ToLower() == dto.Email.ToLower());
            if (user is not null)
                throw new CustomException(403, "User already exsists with email");

            var hash = PasswordHasher.Hash(dto.Password);
            dto.Password = hash.passwordHash;

            User mappedUser = mapper.Map<User>(dto);
            mappedUser.Salt = hash.salt;
            var result = await this.userRepository.InsertAsync(mappedUser);
            await this.userRepository.SaveChangesAsync();
            return this.mapper.Map<UserForResultDto>(result);
        }

        public async Task<IEnumerable<UserForResultDto>> RetriewAllAsync(
                    Expression<Func<User, bool>> expression = null, string search = null)
        {
            var users = userRepository.SelectAll(expression, isTracking: false);

            var result = mapper.Map<IEnumerable<UserForResultDto>>(users);
            if (string.IsNullOrEmpty(search))
            {
                return result.Where(
                    u => u.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return result;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var user = await this.userRepository.SelectAsync(u => u.Id.Equals(id));
            if (user is null)
                throw new CustomException(404, "User not found");

            await this.userRepository.DeleteAsync(user);
            await this.userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<UserForResultDto> RetriewByIdAsync(long id)
        {
            var user = await userRepository.SelectAsync(u => u.Id.Equals(id));
            if (user is null)
                throw new CustomException(404, "User not found");
            return mapper.Map<UserForResultDto>(user);
        }
    }
}
