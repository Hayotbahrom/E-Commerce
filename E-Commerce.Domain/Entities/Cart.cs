using E_Commerce.Domain.Commons;

namespace E_Commerce.Domain.Entities;

public class Cart : Auditable
{
    public long UserId { get; set; }
    public long OrderId { get; set; }
}
