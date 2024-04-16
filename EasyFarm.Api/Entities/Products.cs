using System.ComponentModel.DataAnnotations;

namespace EasyFarm.Api.Entities;

public class ProdCategory
{
    
   public int Id { get; set; }
   public string Category { get; set; }
}





public class Products 
{
    [Key]
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } 
    public UserAccounts Seller { get; set; }
    public ProdCategory ProdCategory { get; set; }
    
    public double ActualPrice { get; set; }
    
    public double OfferPricePrice { get; set; }
}