using E_Commerce.Service.DTOs.Cart;

namespace E_Commerce.Service.Interfaces;

public interface ICartService
{
    public Task<List<CartForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<CartForResultDto> GetByIdAsync(long id);
    public Task<CartForResultDto> CreateAsync(CartForCreationDto dto);
}
