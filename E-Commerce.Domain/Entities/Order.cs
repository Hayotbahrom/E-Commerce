using E_Commerce.Domain.Commons;

namespace E_Commerce.Domain.Entities;

public class Order : Auditable
{
    public long ProductId { get; set; }
    public long Quantity { get; set; }
}
