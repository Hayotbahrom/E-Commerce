using E_Commerce.Service.DTOs.Counties;

namespace E_Commerce.Service.Interfaces;

public interface ICountryService
{
    public Task<List<CountryForResultDto>> GetAllAsync();
    public Task<CountryForResultDto> RemoveAsync(long id);
    public Task<CountryForResultDto> GetByIdAsync(long id);
    public Task<CountryForResultDto> UpdateAsync(CountryForUpdateDto dto);
    public Task<CountryForResultDto> CreateAsync(CountryForCreationDto dto);
}
