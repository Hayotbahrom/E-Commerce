using E_Commerce.Data.Repositories;
using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Users;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Interfaces;


namespace E_Commerce.Service.Services;

public class UserService : IUserService
{
    private long _id;   
    private readonly Repository<User> userRepository = new Repository<User>();
    
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = (await userRepository.SelectAllAsync())
            .FirstOrDefault(u => u.Email.ToLower()==dto.Email.ToLower());
        if (user != null)
        {
            throw new CustomException(409, "User is already exist");
        }
        User person = new User()
        {
            Id = _id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Balance = dto.Balance,
            CountryCode = dto.CountryCode,
            CreatedAt = DateTime.UtcNow,
        };

        await userRepository.InsertAsync(person);

        var result = new UserForResultDto()
        {
            Id = _id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Password = person.Password,
            Balance = person.Balance,
            CountryCode = person.CountryCode,
        };

        return result;
    }

    public async Task<List<UserForResultDto>> GetAllAsync()
    {
        List<User> users = await userRepository.SelectAllAsync();
        List<UserForResultDto> mappedUsers = new List<UserForResultDto>();

        foreach (var user in users)
        {
            var item = new UserForResultDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Balance = user.Balance,
                CountryCode = user.CountryCode
            };
            mappedUsers.Add(item);
        }
        return mappedUsers;
    }

    public Task<UserForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task GenerateIdAsync()
    {
        var users = await userRepository.SelectAllAsync();
        if(users.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var user = users[users.Count() - 1];
            this._id = ++user.Id;
        }
    }
}
