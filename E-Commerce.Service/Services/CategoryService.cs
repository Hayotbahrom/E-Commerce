using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Categories;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services;

public class CategoryService : ICategoryService
{
    private long _id;
    private readonly Repository<Category> categoryRepository = new Repository<Category>();
    public async Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto)
    {
        var category = (await categoryRepository.SelectAllAsync()).
            FirstOrDefault(c => c.Name.ToLower() == dto.Name.ToLower());
        if (category != null)
            throw new CustomException(409, "Category is already exist");

        await GenerateIdAsync();

        var categoryForInsert = new Category()
        {
            Id = _id,
            Name = dto.Name,
        };

        await categoryRepository.InsertAsync(categoryForInsert);

        var result = new CategoryForResultDto()
        {
            Id = _id,
            Name = categoryForInsert.Name,
        };

        return result;
    }

    public async Task<List<CategoryForResultDto>> GetAllAsync()
    {
        var categories = await categoryRepository.SelectAllAsync();
        var mappedCategories = new List<CategoryForResultDto>();

        foreach (var category in categories)
        {
            var item = new CategoryForResultDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
            mappedCategories.Add(item);
        }

        return mappedCategories;
    }

    public async Task<CategoryForResultDto> GetByIdAsync(long id)
    {
        var category = await categoryRepository.SelectByIdAsync(id);
        if (category == null)
            throw new CustomException(404, "Category is not found");

        var result = new CategoryForResultDto()
        {
            Id = id,
            Name = category.Name,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var category = await categoryRepository.SelectByIdAsync(id);
        if (category == null)
            throw new CustomException(404, "Category is not found");

        await categoryRepository.DeleteAsync(id);

        return true;
    }

    public async Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto)
    {
        var category = await categoryRepository.SelectByIdAsync(dto.Id);
        if (category == null)
            throw new CustomException(404, "Category is not found");

        var mappedCategory = new Category()
        {
            Id = dto.Id,
            Name = dto.Name,
            UpdatedAt = DateTime.UtcNow,
        };

        await categoryRepository.UpdateAsync(mappedCategory);

        var result = new CategoryForResultDto()
        {
            Id = dto.Id,
            Name = dto.Name,
        };

        return result;
    }


    public async Task GenerateIdAsync()
    {
        var categories = await categoryRepository.SelectAllAsync();
        if (categories.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var category = categories[categories.Count() - 1];
            this._id = ++category.Id;
        }
    }

}