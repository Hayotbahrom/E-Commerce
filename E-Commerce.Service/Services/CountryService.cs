using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Counties;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;

namespace E_Commerce.Service.Services
{
    public class CountryService : ICountryService
    {
        private  long _id;
        private readonly Repository<Country> countryRepository = new Repository<Country>();
        public async Task<CountryForResultDto> CreateAsync(CountryForCreationDto dto)
        {
            await GenerateIdAsync();

            Country country = new Country()
            {
                Id = _id,
                Name = dto.Name,
                CountryCode = dto.CountryCode,
                CreatedAt = DateTime.UtcNow
            };
            await countryRepository.InsertAsync(country);

            var result = new CountryForResultDto()
            {
                Id = _id,
                Name = dto.Name,
                CountryCode = dto.CountryCode
            };

            return result;
        }

        public async Task<List<CountryForResultDto>> GetAllAsync()
        {
            List<Country> countryList = await countryRepository.SelectAllAsync();
            List<CountryForResultDto> mappedCountry = new List<CountryForResultDto>();

            foreach (var country in countryList)
            {
                var item = new CountryForResultDto()
                {
                    Id = country.Id,
                    Name = country.Name,
                    CountryCode = country.CountryCode
                };
                mappedCountry.Add(item);
            }
            return mappedCountry;
        }

        public async Task<CountryForResultDto> GetByIdAsync(long id)
        {
            var country = await countryRepository.SelectByIdAsync(id);
            if (country == null)
                throw new CustomException(404, "asdasd");

            var result = new CountryForResultDto()
            {
                Id = country.Id,
                Name = country.Name,
                CountryCode = country.CountryCode
            };

            return result;
        }

        public async Task GenerateIdAsync()
        {
            var sellers = await countryRepository.SelectAllAsync();
            if (sellers.Count == 0)
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
}
