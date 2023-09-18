using E_Commerce.Service.DTOs.Orders;

namespace E_Commerce.Service.Interfaces;

public interface IOrderService
{
    public Task<List<OrderForResultDto>> GetAllAsync();
    public Task<OrderForResultDto> RemoveAsync(long id);
    public Task<OrderForResultDto> GetByIdAsync(long id);
    public Task<OrderForResultDto> UpdateAsync(OrderForUpdateDto dto);
    public Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto);
}
