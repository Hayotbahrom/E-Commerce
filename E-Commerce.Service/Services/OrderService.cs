using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Orders;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;


namespace E_Commerce.Service.Services;

public class OrderService : IOrderService
{
    private long _id;
    private readonly Repository<Order> orderRepository = new Repository<Order>();


    public async Task GenerateIdAsync()
    {
        var orders = await orderRepository.SelectAllAsync();
        if (orders.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var seller = orders[orders.Count() - 1];
            this._id = ++seller.Id;
        }
    }

    public async Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
    {
        GenerateIdAsync();
        Order order = new Order()
        {
            Id = _id,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            CreatedAt = DateTime.UtcNow
        };
        await orderRepository.InsertAsync(order);

        var result = new OrderForResultDto()
        {
            Id = _id,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity
        };

        return result;
    }
    public async Task<List<OrderForResultDto>> GetAllAsync()
    {
        List<Order> orders = await orderRepository.SelectAllAsync();
        List<OrderForResultDto> mappedOrders = new List<OrderForResultDto>();

        foreach (var order in orders)
        {
            var item = new OrderForResultDto()
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
            };
            mappedOrders.Add(item);
        }

        return mappedOrders;
    }

    public async Task<OrderForResultDto> GetByIdAsync(long id)
    {
        var order = await orderRepository.SelectByIdAsync(id);
        if (order == null)
            throw new CustomException(404, "not found");

        var result = new OrderForResultDto()
        {
            Id = order.Id,
            ProductId = order.ProductId,
            Quantity = order.Quantity
        };
        
        return result;
    }
}
