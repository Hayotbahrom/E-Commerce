using E_Commerce.Service.DTOs.Categories;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services;

public class CategoryService : ICategoryService
{
    public Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryForResultDto> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
