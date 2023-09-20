using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Sellers;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;
using Microsoft.VisualBasic;

namespace E_Commerce.Service.Services;

public class SellerService : ISellerService
{
    private long _id;
    private readonly Repository<Seller> sellerRepository = new Repository<Seller>();


    public async Task<SellerForResultDto> CreateAsync(SellerForCreationDto dto)
    {
        await GenerateIdAsync();

        var seller = (await sellerRepository.SelectAllAsync())
            .FirstOrDefault(s => s.FirstName.ToLower() == dto.FirstName.ToLower());

        if (seller != null)
        {
            throw new CustomException(409, "User is already exist");
        }

        Seller seller1 = new Seller()
        {
            Id = _id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CountryCode = dto.CountryCode,
            CreatedAt = DateTime.UtcNow
        };
        await sellerRepository.InsertAsync(seller1);

        var result = new SellerForResultDto()
        {
            Id= _id,
            FirstName = seller1.FirstName,
            LastName = seller1.LastName,
            CountryCode = seller1.CountryCode
        };

        return result;
    }

    public async Task<List<SellerForResultDto>> GetAllAsync()
    {
        List<Seller> sellers = await sellerRepository.SelectAllAsync();
        List<SellerForResultDto> mappedSellers = new List<SellerForResultDto>();

        foreach (var seller  in sellers)
        {
            var item = new SellerForResultDto()
            {
                Id = seller.Id,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                CountryCode = seller.CountryCode
            };
            mappedSellers.Add(item);
        }
        return mappedSellers;
    }

    public async Task<SellerForResultDto> GetByIdAsync(long id)
    {
        var seller = await sellerRepository.SelectByIdAsync(id);
        if (seller == null)
            throw new CustomException(404, "Seller is not found");

        var result = new SellerForResultDto()
        {
            Id = seller.Id,
            FirstName = seller.FirstName,
            LastName = seller.LastName,
            CountryCode = seller.CountryCode
        };
        
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var seller = sellerRepository.SelectByIdAsync(id);
        if (seller == null)
            throw new CustomException(404, "Seller is not found ");

        await sellerRepository.DeleteAsync(id);
        return true;
    }

    public async Task<SellerForResultDto> UpdateAsync(SellerForUpdateDto dto)
    {
        var seller = await sellerRepository.SelectByIdAsync(dto.Id);
        if (seller == null)
            throw new CustomException(404, "is not found");

        var mappedSeller = new Seller()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CountryCode = dto.CountryCode,
            UpdatedAt = DateTime.UtcNow
        };
        await sellerRepository.UpdateAsync(mappedSeller);

        var result = new SellerForResultDto()
        {
            Id = mappedSeller.Id,
            FirstName = mappedSeller.FirstName,
            LastName = mappedSeller.LastName,
            CountryCode = mappedSeller.CountryCode
        };
        return result;
    }

     public async Task GenerateIdAsync()
    {
        var sellers = await sellerRepository.SelectAllAsync();
        if(sellers.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var seller = sellers[sellers.Count() - 1];
            this._id = ++seller.Id;
        }
    }
}
