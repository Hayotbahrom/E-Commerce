using E_Commerce.Service.DTOs.Users;

namespace E_Commerce.Service.Interfaces;

public interface IUserService
{
    public Task<List<UserForResultDto>> GetAllAsync();
    public Task<UserForResultDto> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
}
