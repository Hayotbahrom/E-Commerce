using E_Commerce.Domain.Commons;

namespace E_Commerce.Domain.Entities;

public class Product : Auditable
{
    public string Name { get; set; }
    public long SellerId { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}
