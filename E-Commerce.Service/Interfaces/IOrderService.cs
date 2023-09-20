using E_Commerce.Service.DTOs.Orders;

namespace E_Commerce.Service.Interfaces;

public interface IOrderService
{
    public Task<List<OrderForResultDto>> GetAllAsync();
    public Task<OrderForResultDto> GetByIdAsync(long id);
}
