using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Views;
using Microsoft.EntityFrameworkCore;

namespace EasyFarm.Api.Services.Ecom;

public class ProductService : IProductService
{
    private readonly AppDbContext _appDbContext;

    public ProductService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ResponseWrapper<List<SellingProducts>>> GetSellingProducts(ProdCategoryVw productsCategories)
    {
        try
        {
            List<SellingProducts> sellingProducts = new List<SellingProducts>();
            
            var productsData = await _appDbContext.TblProducts.Include(i =>
                    i.ProdCategory).Include(a => a.Seller).Where(p => p.ProdCategory.Category == productsCategories.Category)
                .ToListAsync();
            
            if (productsData.Count != 0)
            {
                foreach (var p in productsData )
                {
                    sellingProducts.Add(new SellingProducts
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        Category = p.ProdCategory.Category,
                        Seller =  $"{p.Seller.FirstName} {p.Seller.LastName}" ,
                        Price = p.ActualPrice
                        
                    });
                }

                return new ResponseWrapper<List<SellingProducts>>(200, "success", true, sellingProducts);

            }
            return new ResponseWrapper<List<SellingProducts>>(200, "success", false, sellingProducts);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<ProdCategory>> AddCategory(ProdCategory category)
    {
        try
        {
            await _appDbContext.TblProdCategories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();

            return new ResponseWrapper<ProdCategory>(200, "success", true, category);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<CartList>> AddToCart(AddToCartVw addToCartVw)
    {
        try
        {
            CartList cartList = new CartList();

            var buyer = await _appDbContext.TblUserAccounts.Where(u => u.Email == addToCartVw.UserEmail)
                .FirstOrDefaultAsync();

            var prod = await _appDbContext.TblProducts.Include(i => i.Seller).Where(a => a.ProductId == addToCartVw.ProductId).FirstOrDefaultAsync();
            
            cartList.UserAccounts = buyer;
            cartList.Products = prod;

            await _appDbContext.AddAsync(cartList);
            await _appDbContext.SaveChangesAsync();

            return new ResponseWrapper<CartList>(200, "success", true, cartList);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<ResponseWrapper<List<CartList>>> GetCartItem(string email)
    {
        try
        {
            var cartList = await _appDbContext.TblCart.Include(u=>u.UserAccounts)
                .Include(p => p.Products).Include(c =>c.Products.ProdCategory).Where(c => c.UserAccounts.Email == email).ToListAsync();

            if (cartList.Count != 0)
            {
                return new ResponseWrapper<List<CartList>>(200, "success", true, cartList);
            }

            return new ResponseWrapper<List<CartList>>(200, "Cart Empty", false, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<CartList>> RemoveFromCart(int id)
    {
        try
        {
            var removeCartItem = await _appDbContext.TblCart.Where(r => r.Id == id).FirstOrDefaultAsync();

            _appDbContext.TblCart.Remove(removeCartItem);
            await _appDbContext.SaveChangesAsync();
            return new ResponseWrapper<CartList>(200, "success", true, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<OrdersVw>> AddOrders(OrdersVw ordersVws)
    {
        try
        {
            
            if (ordersVws.CartItems.Count != 0)
            {

                foreach (var cart in  ordersVws.CartItems)
                {
                    var prodItem = await _appDbContext.TblProducts.Include(c => c.ProdCategory)
                        .FirstOrDefaultAsync(a => a.ProductId == cart.Products.ProductId);
                    
                    Orders orders = new Orders();
           
                    orders.OrderId = new Guid();
                    orders.Products = prodItem ;
                    orders.User = ordersVws.UserEmail;
                    orders.OrderDate = DateTime.Now.ToUniversalTime();

                    

                    await _appDbContext.TblOrders.AddAsync(orders);
                    await _appDbContext.SaveChangesAsync();
                    var removeFromCart = await _appDbContext.TblCart.Where(p => p.Products == prodItem).FirstOrDefaultAsync();

                     _appDbContext.TblCart.Remove(removeFromCart);
                     await _appDbContext.SaveChangesAsync();



                }

                return new ResponseWrapper<OrdersVw>(200, "Success", true, ordersVws);
            }
            return new ResponseWrapper<OrdersVw>(500, "Invalid Orders", true, null);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<List<Orders>>> GetAllOrders(string email)
    {
        try
        {
            List<Orders> ordersList = new List<Orders>();
            var allOrders = await _appDbContext.TblOrders.Include(i => i.Products.ProdCategory).Include(s => s.Products.Seller)
                .Where(e => e.User == email).ToListAsync();
            if (allOrders.Count != 0)
            {
                foreach (var order in allOrders)
                {
                    ordersList.Add(new Orders
                    {
                        OrderId = order.OrderId,
                        Products = order.Products,
                        User = order.User,
                        OrderDate = order.OrderDate
                        
                    });
                }

                return new ResponseWrapper<List<Orders>>(200, "All Orders", true, ordersList);
            }

            return new ResponseWrapper<List<Orders>>(200, "Orders not found", true, ordersList);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}