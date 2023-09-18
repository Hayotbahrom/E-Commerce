namespace E_Commerce.Service.DTOs.Sellers;

public interface SellerForUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CountryCode { get; set; }
}
