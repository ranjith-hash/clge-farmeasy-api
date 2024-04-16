using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Views;

namespace EasyFarm.Api.Services.Seller;

public class GetSellerOrders
{
    public Guid OrderId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public string CustomerEmail { get; set; }

    public double Price { get; set; }

}


public class AddProductsVw
{
    public string UserEmail { get; set; }
    public int ProdCategory { get; set; }
    public string ProductName { get; set; }
    public double ActualPrice { get; set; }
    public double OfferPrice { get; set; }
    
}


public interface ISellerService
{

    Task<ResponseWrapper<List<ProdCategory>>> GetCategoryies();
    
    Task<ResponseWrapper<List<GetSellerOrders>>> GetSellerOrder(UserEmail sellerEmail);
    Task<ResponseWrapper<List<Products>>> GetSellerProducts(UserEmail sellerEmail);

    Task<ResponseWrapper<Products>> AddSellerProducts(AddProductsVw addProductsVw);
}