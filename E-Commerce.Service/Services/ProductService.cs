using E_Commerce.Service.DTOs.Products;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services;

public class ProductService : IProductService
{
    public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductForResultDto> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
