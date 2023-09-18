using E_Commerce.Domain.Commons;

namespace E_Commerce.Domain.Entities;

public class User : Auditable
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public long CountryCode { get; set; }
    
}
