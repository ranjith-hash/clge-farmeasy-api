using System.ComponentModel.DataAnnotations;

namespace EasyFarm.Api.Entities;

public class UserAccounts 
{
    [Key]
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
    public string Password { get; set; }= string.Empty;
    public bool IsSeller { get; set; } = false;
}