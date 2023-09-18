using E_Commerce.Service.DTOs.Orders;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services;

public class OrderService : IOrderService
{
    public Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderForResultDto> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderForResultDto> UpdateAsync(OrderForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
