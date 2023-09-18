namespace E_Commerce.Service.DTOs.Products;

public class ProductForCreationDto
{
    public string Name { get; set; }
    public long SellerId { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}
