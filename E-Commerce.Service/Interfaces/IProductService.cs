using E_Commerce.Service.DTOs.Products;

namespace E_Commerce.Service.Interfaces;

public interface IProductService
{
    public Task<List<ProductForResultDto>> GetAllAsync();
    public Task<ProductForResultDto> RemoveAsync(long id);
    public Task<ProductForResultDto> GetByIdAsync(long id);
    public Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto);
    public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
}
