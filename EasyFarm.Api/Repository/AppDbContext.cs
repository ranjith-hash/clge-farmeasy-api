using EasyFarm.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyFarm.Api;

public class AppDbContext : DbContext
{
   

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    

    public DbSet<UserAccounts> TblUserAccounts { get; set; }
    public DbSet<Orders> TblOrders { get; set; }
    public DbSet<ProdCategory> TblProdCategories { get; set; }

    public DbSet<Products> TblProducts { get; set; }
    public DbSet<CartList> TblCart { get; set; }
    
    
}