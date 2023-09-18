using E_Commerce.Service.DTOs.Sellers;

namespace E_Commerce.Service.Interfaces;

public interface ISellerService
{
    public Task<List<SellerForResultDto>> GetAllAsync();
    public Task<SellerForResultDto> RemoveAsync(long id);
    public Task<SellerForResultDto> GetByIdAsync(long id);
    public Task<SellerForResultDto> UpdateAsync(SellerForUpdateDto dto);
    public Task<SellerForResultDto> CreateAsync(SellerForCreationDto dto);
}
