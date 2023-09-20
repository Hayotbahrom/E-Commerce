using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Products;
using E_Commerce.Service.DTOs.Sellers;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace E_Commerce.Service.Services;

public class ProductService : IProductService
{
    private long _id;
    private readonly Repository<Product> productRepository = new Repository<Product>();
    public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        GenerateIdAsync();
        var product = (await productRepository.SelectAllAsync())
            .FirstOrDefault(s => s.Name == dto.Name);

        if (product != null)
        {
            throw new CustomException(409, "Product is already exist");
        }

        Product seller1 = new Product()
        {
            Id = _id,
            Name = dto.Name,
            SellerId = dto.SellerId,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            CreatedAt = DateTime.UtcNow
        };
        await productRepository.InsertAsync(seller1);

        var result = new ProductForResultDto()
        {
            Id = _id,
            Name = dto.Name,
            SellerId = dto.SellerId,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
        };

        return result;
    }

    public async Task<List<ProductForResultDto>> GetAllAsync()
    {
        List<Product> products = await productRepository.SelectAllAsync();
        List<ProductForResultDto> mappedProduct = new List<ProductForResultDto>();

        foreach (var product in products)
        {
            var item = new ProductForResultDto()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                SellerId = product.SellerId
            };
            mappedProduct.Add(item);
        }

        return mappedProduct;
    }

    public async Task<ProductForResultDto> GetByIdAsync(long id)
    {
        var product = await productRepository.SelectByIdAsync(id);
        if (product == null)
            throw new CustomException(404, "product is not found exception");

        var result = new ProductForResultDto()
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Price = product.Price
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var product = productRepository.SelectByIdAsync(id);
        if (product == null)
            throw new CustomException(404, "Product is not found");
        
        await productRepository.DeleteAsync(id);
        return true;
    }

    public async Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto)
    {
        var product = await productRepository.SelectByIdAsync(dto.Id);
        if (product == null)
            throw new CustomException(404, "is not found");
        
        var mappedProduct = new Product()
        {
            Id = dto.Id,
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            SellerId = dto.SellerId,
            UpdatedAt = DateTime.UtcNow
        };

        await productRepository.UpdateAsync(mappedProduct);

        var result = new ProductForResultDto()
        {
            Id = mappedProduct.Id,
            Name = mappedProduct.Name,
            CategoryId = mappedProduct.CategoryId,
            SellerId = mappedProduct.SellerId,
            Price = mappedProduct.Price,
        };

        return result;
    }
    public async Task GenerateIdAsync()
    {
        var products = await productRepository.SelectAllAsync();
        if (products.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var seller = products[products.Count() - 1];
            this._id = ++seller.Id;
        }
    }
}
