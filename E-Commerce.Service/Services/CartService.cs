using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Cart;
using E_Commerce.Service.DTOs.Users;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services;

public class CartService : ICartService
{
    private long _id;
    private readonly Repository<Cart> cartRepository = new Repository<Cart>();

    public async Task<List<CartForResultDto>> GetAllAsync()
    {
        var carts = await cartRepository.SelectAllAsync();
        var mappedCarts = new List<CartForResultDto>();

        foreach (var cart in carts)
        {
            var item = new CartForResultDto()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                OrderId = cart.OrderId,
            };
            mappedCarts.Add(item);
        }
        return mappedCarts;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var cart = await cartRepository.SelectByIdAsync(id);
        if (cart == null)
            throw new CustomException(404, "cart is not found");

        await cartRepository.DeleteAsync(id);

        return true;
    }

    public async Task<CartForResultDto> GetByIdAsync(long id)
    {
        var cart = await cartRepository.SelectByIdAsync(id);
        if (cart == null)
            throw new CustomException(404, "Cart is not found");

        var result = new CartForResultDto()
        {
            Id = cart.Id,
            UserId = cart.UserId,
            OrderId = cart.OrderId,
        };

        return result;
    }

    public async Task<CartForResultDto> CreateAsync(CartForCreationDto dto)
    {
        await GenerateIdAsync();

        var cartForInsert = new Cart()
        {
            Id = _id,
            OrderId = dto.OrderId,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow,
        };

        await cartRepository.InsertAsync(cartForInsert);

        var result = new CartForResultDto()
        {
            Id = _id,
            OrderId = dto.OrderId,
            UserId = dto.UserId,
        };

        return result;
    }


    public async Task GenerateIdAsync()
    {
        var carts = await cartRepository.SelectAllAsync();
        if (carts.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var cart = carts[carts.Count() - 1];
            this._id = ++cart.Id;
        }
    }
}