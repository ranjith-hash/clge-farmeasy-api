using EasyFarm.Api.Entities;

namespace EasyFarm.Api.Views;

public class ProdCategoryVw
{
    public string Category { get; set; }
}


public class SellingProducts
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } 
    public string Seller { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
}


public class AddToCartVw
{
    public Guid ProductId { get; set; }
    public string UserEmail { get; set; }

    
}


public class OrdersVw
{

    public List<CartList> CartItems { get; set; }
    public string UserEmail { get; set; }
    
}