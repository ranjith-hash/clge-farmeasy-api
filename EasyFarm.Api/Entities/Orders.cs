using System.ComponentModel.DataAnnotations;

namespace EasyFarm.Api.Entities;

public class CartList
{
    public int Id { get; set; }
    public UserAccounts UserAccounts { get; set; }
    public Products Products { get; set; }
}

public class Orders
{
    [Key]
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string User { get; set; }
    public Products Products { get; set; }

}