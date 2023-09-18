using E_Commerce.Service.DTOs.Categories;

namespace E_Commerce.Service.Interfaces;

public interface ICategoryService
{
    public Task<List<CategoryForResultDto>> GetAllAsync();
    public Task<CategoryForResultDto> RemoveAsync(long id);
    public Task<CategoryForResultDto> GetByIdAsync(long id);
    public Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto);
    public Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto);
}
