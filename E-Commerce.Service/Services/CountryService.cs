using E_Commerce.Service.DTOs.Counties;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services
{
    public class CountryService : ICountryService
    {
        public Task<CountryForResultDto> CreateAsync(CountryForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<CountryForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CountryForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryForResultDto> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryForResultDto> UpdateAsync(CountryForUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
