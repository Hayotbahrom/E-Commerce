namespace E_Commerce.Service.DTOs.Orders;

public class OrderForUpdateDto
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public long Quantity { get; set; }
}
