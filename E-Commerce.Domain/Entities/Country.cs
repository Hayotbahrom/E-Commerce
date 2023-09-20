using E_Commerce.Domain.Commons;

namespace E_Commerce.Domain.Entities;

public class Country : Auditable
{
    public string Name { get; set; }
    public string CountryCode { get; set; }
}
