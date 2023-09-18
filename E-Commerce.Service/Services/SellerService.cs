using E_Commerce.Service.DTOs.Sellers;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services;

public class SellerService : ISellerService
{
    public Task<SellerForResultDto> CreateAsync(SellerForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<SellerForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SellerForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<SellerForResultDto> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<SellerForResultDto> UpdateAsync(SellerForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
