using E_Commerce.Domain.Commons;

namespace E_Commerce.Domain.Entities;

public class Seller : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long CountryCode { get; set; }
}
