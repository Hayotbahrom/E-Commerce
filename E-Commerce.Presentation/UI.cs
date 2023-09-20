using E_Commerce.Domain.Entities;
using E_Commerce.Service.DTOs.Categories;
using E_Commerce.Service.DTOs.Counties;
using E_Commerce.Service.DTOs.Orders;
using E_Commerce.Service.DTOs.Products;
using E_Commerce.Service.DTOs.Sellers;
using E_Commerce.Service.DTOs.Users;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Services;
using Newtonsoft.Json;

namespace E_Commerce.Presentation;

public class UI
{
    public async Task RunCodeAsync()
    {
        bool lampMain = true;
        while (lampMain)
        {
            Console.Write(@"E COMMERCE
1-user
2-seller 
3-admin

other => exit
");
            string position = (Console.ReadLine());

            switch (position)
            {
                case "1":
                    Console.WriteLine(@"
1-create
2-update
4-get by id
5-get all
6- sell product

");
                    UserService userService = new UserService();
                    ProductService productService = new ProductService();
                    CategoryService categoryService = new CategoryService();
                    OrderService orderService = new OrderService();
                    CartService cartService = new CartService();
                    string userChoice = (Console.ReadLine());
                    switch (userChoice)
                    {
                        case "1":
                            {

                                var dto = new UserForCreationDto();
                                Console.WriteLine("enter user informations:");
                                Console.Write("FirstName: ");
                                dto.FirstName = Console.ReadLine();
                                Console.Write("Lastname: ");
                                dto.LastName = Console.ReadLine();
                                Console.Write("Email: ");
                                dto.Email = Console.ReadLine();
                                Console.Write("Password: ");
                                dto.Password = Console.ReadLine();
                                Console.Write("Balance: ");
                                dto.Balance = decimal.Parse(Console.ReadLine());
                                Console.Write("CountryCode: ");
                                dto.CountryCode = Console.ReadLine();

                                var path = "C:\\Users\\Hayotbahrom\\Desktop\\E-commerce 2\\E-Commerce.Data\\Databases\\AllCountries.json";
                                CountryService countryService = new CountryService();
                                var str = await File.ReadAllTextAsync(path);
                                var country = (JsonConvert.DeserializeObject<List<Country>>(str))
                                    .FirstOrDefault(c => c.CountryCode.ToUpper() == dto.CountryCode.ToUpper());
                                if (country == null)
                                    throw new CustomException(404, "Country code is not found");

                                var resultCountry = new CountryForCreationDto()
                                {
                                    CountryCode = country.CountryCode,
                                    Name = country.Name,
                                };
                                await countryService.CreateAsync(resultCountry);

                                var result = await userService.CreateAsync(dto);
                            }

                            break;

                        case "2":
                            {

                                var dto = new UserForUpdateDto();
                                Console.WriteLine("enter user informations:\nid: ");
                                dto.Id = long.Parse(Console.ReadLine());
                                Console.Write("FirstName: ");
                                dto.FirstName = Console.ReadLine();
                                Console.Write("Lastname: ");
                                dto.LastName = Console.ReadLine();
                                Console.Write("Email: ");
                                dto.Email = Console.ReadLine();
                                Console.Write("Password: ");
                                dto.Password = Console.ReadLine();
                                Console.Write("Balance: ");
                                dto.Balance = decimal.Parse(Console.ReadLine());
                                Console.Write("CountryCode: ");
                                dto.CountryCode = Console.ReadLine();

                                var result = await userService.UpdateAsync(dto);
                                Console.WriteLine("successfully Updated");
                            }

                            break;

                        case "4":
                            Console.WriteLine("enter id : ");
                            var smthId = long.Parse(Console.ReadLine());
                            var res = await userService.GetByIdAsync(smthId);
                            Console.WriteLine($"{res.Id} | {res.FirstName} | {res.LastName}");
                            break;
                        case "5":
                            var userList = await userService.GetAllAsync();
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            foreach (var user in userList)
                            {
                                Console.WriteLine($"| {user.Id} {user.FirstName} {user.Email} {user.CountryCode}");
                            }
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");

                            break;
                        case "6":
                            var products = await productService.GetAllAsync();
                            var category = await categoryService.GetAllAsync();
                            if (products != null)
                            {
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"{product.Id} -- {product.Name}--{product.Price}--{category.Where(c => c.Id == product.CategoryId).Select(c => c.Name)}");
                                }
                                bool isOrder = true;
                                while(isOrder)
                                {
                                    OrderForCreationDto orderForCreationDto = new OrderForCreationDto();
                                    Console.Write("enter productId: ");
                                    orderForCreationDto.ProductId = long.Parse(Console.ReadLine());
                                    Console.Write("enter quantity:  ");
                                    orderForCreationDto.Quantity = long.Parse(Console.ReadLine());
                                    var orderRes = await orderService.CreateAsync(orderForCreationDto);
                                    Console.Write("do you want to buy any product again? (yes :1/others -no)");
                                    if (Console.ReadLine()!="1")
                                        isOrder = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" sorry we have no products");
                            }
                            break;
                    }


                    break;
                case "2":
                    {
                        SellerService sellerService = new SellerService();
                        SellerForCreationDto sellerForCreationDto = new SellerForCreationDto();
                        SellerForUpdateDto sellerForUpdateDto = new SellerForUpdateDto();
                        ProductService productServiceSeller = new ProductService();
                        CountryService countryService1 = new CountryService();
                        CategoryService categoryService1 = new CategoryService();

                        Console.WriteLine("-------------SELLER-------------------");
                        Console.WriteLine(@"
1-create
2-update
5-get all
6-add products
");
                        Console.Write("enter command: ");
                        string sellerChoice=Console.ReadLine();

                        switch (sellerChoice)
                        {
                            case "1":
                                {
                                    Console.WriteLine("enter seller infos:");
                                    Console.Write("firstname: ");
                                    sellerForCreationDto.FirstName = Console.ReadLine();
                                    Console.Write("Lastname: ");
                                    sellerForCreationDto.LastName = Console.ReadLine();
                                    Console.Write("CountryCode: ");
                                    sellerForCreationDto.CountryCode = Console.ReadLine();

                                    var path = "C:\\Users\\Hayotbahrom\\Desktop\\E-commerce 2\\E-Commerce.Data\\Databases\\AllCountries.json";
                                    CountryService countryService = new CountryService();
                                    var str = await File.ReadAllTextAsync(path);
                                    var country = (JsonConvert.DeserializeObject<List<Country>>(str))
                                        .FirstOrDefault(c => c.CountryCode.ToUpper() == sellerForCreationDto.CountryCode.ToUpper());
                                    if (country == null)
                                        throw new CustomException(404, "Country code is not found");

                                    var resultCountry = new CountryForCreationDto()
                                    {
                                        CountryCode = country.CountryCode,
                                        Name = country.Name,
                                    };
                                    await countryService.CreateAsync(resultCountry);
                                    var sellerRes = await sellerService.CreateAsync(sellerForCreationDto);

                                }

                                break;
                            case "2":
                                {
                                    var dto = new SellerForUpdateDto();
                                    Console.WriteLine("enter user informations:\nid: ");
                                    dto.Id = long.Parse(Console.ReadLine());
                                    Console.Write("FirstName: ");
                                    dto.FirstName = Console.ReadLine();
                                    Console.Write("Lastname: ");
                                    dto.LastName = Console.ReadLine();                                    
                                    Console.Write("CountryCode: ");
                                    dto.CountryCode = Console.ReadLine();

                                    var result = await sellerService.UpdateAsync(dto);
                                    Console.WriteLine("successfully Updated");
                                }
                                
                                break;
                            case "5":
                                {
                                    var userList = await sellerService.GetAllAsync();
                                    Console.WriteLine("+--------------------------------------------------+");
                                    foreach (var user in userList)
                                    {
                                        Console.WriteLine($"| {user.Id} {user.FirstName} {user.CountryCode}");
                                    }
                                    Console.WriteLine("+---------------------------------------------------+");

                                }
                                break;
                            case "6":
                                {
                                    var products = await productServiceSeller.GetAllAsync();
                                    var categories = await categoryService1.GetAllAsync();
                                    CategoryForCreationDto categoryDto = new CategoryForCreationDto();
                                    
                                    Console
                                        .WriteLine("enter product infos:");
                                    
                                    ProductForCreationDto productForCreationDto = new ProductForCreationDto();
                                    Console.Write("Name: ");
                                    productForCreationDto.Name = Console.ReadLine();
                                    Console.Write("Price: ");
                                    productForCreationDto.Price = decimal.Parse(Console.ReadLine());
                                    Console.Write("CategoryId: ");
                                    productForCreationDto.CategoryId = long.Parse(Console.ReadLine());

                                    await productServiceSeller.CreateAsync(productForCreationDto);
                                    var existCategory = categories.FirstOrDefault(c => c.Id == productForCreationDto.CategoryId);
                                    var categoryCreation = new CategoryForCreationDto()
                                    {
                                        Name = existCategory.Name
                                    };
                                    if (existCategory is null)
                                        await categoryService1.CreateAsync(categoryCreation);


                                }
                                break;
                                default: Console.WriteLine("wrong input");
                                break;
                        }

                    }
                    break;
                case "3":
                    break;
                default: break;
            }

            Console.WriteLine("do you whant continue ? yes=> 1/ others --> exit");
            if (Console.ReadLine()!="1")
                lampMain = false;
        }

        



    }
}
