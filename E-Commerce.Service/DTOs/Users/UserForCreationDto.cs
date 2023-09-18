namespace E_Commerce.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public long CountryCode { get; set; }
}
