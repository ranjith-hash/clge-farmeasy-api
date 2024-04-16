using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Views;
using Microsoft.EntityFrameworkCore;

namespace EasyFarm.Api.Services.Seller;

public class SellerService : ISellerService
{
    private readonly AppDbContext _appDbContext;

    public SellerService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ResponseWrapper<List<ProdCategory>>> GetCategoryies()
    {
        try
        {
            var categrory = await _appDbContext.TblProdCategories.ToListAsync();
            return new ResponseWrapper<List<ProdCategory>>(200, "success", true, categrory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<List<GetSellerOrders>>> GetSellerOrder(UserEmail sellerEmail)
    {
        try
        {
            var seller = await _appDbContext.TblUserAccounts.Where(u => u.IsSeller && u.Email == sellerEmail.Email)
                .FirstOrDefaultAsync();

            if (seller != null)
            {
                List<GetSellerOrders> sellerOrdersList = new List<GetSellerOrders>();

                var sellerOrders = await  _appDbContext.TblOrders.Include(u => u.Products.Seller).Include(c =>c.Products.ProdCategory)
                    .Where(s => s.Products.Seller.Email == sellerEmail.Email).ToListAsync();

                if (sellerOrders.Count != 0)
                {

                    foreach (var so in sellerOrders)
                    {
                        sellerOrdersList.Add(new GetSellerOrders
                        {
                            OrderId = so.OrderId,
                            ProductName = so.Products.ProductName,
                            Category = so.Products.ProdCategory.Category,
                            CustomerEmail = so.User,
                            Price = so.Products.OfferPricePrice
                            
                        });
                    }

                    return new ResponseWrapper<List<GetSellerOrders>>(200, "success", true, sellerOrdersList);

                }

                return new ResponseWrapper<List<GetSellerOrders>>(200, "No Orders found", true, sellerOrdersList);

            }

            return new ResponseWrapper<List<GetSellerOrders>>(200, "Invalid Seller", false, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }

    public async Task<ResponseWrapper<List<Products>>> GetSellerProducts(UserEmail sellerEmail)
    {
        try
        {
            var sellerProds = await _appDbContext.TblProducts.Include(u => u.Seller).Include(c => c.ProdCategory)
                .Where(p => p.Seller.Email == sellerEmail.Email).ToListAsync();

            if (sellerProds.Count != 0)
            {
                List<Products> productsList = new List<Products>();

                foreach (var prod in sellerProds)
                {
                    productsList.Add(new Products
                    {
                        ProductId = prod.ProductId,
                        ProductName = prod.ProductName,
                        ProdCategory = prod.ProdCategory,
                        ActualPrice = prod.ActualPrice,
                        OfferPricePrice = prod.OfferPricePrice
                    });
                }

                return new ResponseWrapper<List<Products>>(200, "success", true, productsList);

            }

            return new ResponseWrapper<List<Products>>(200, "Products not found", false, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseWrapper<Products>> AddSellerProducts(AddProductsVw addProductsVw)
    {
        try
        {
            Products products = new Products();
            
            var seller = await _appDbContext.TblUserAccounts.Where(u => u.Email == addProductsVw.UserEmail)
                .FirstOrDefaultAsync();

            var category = await _appDbContext.TblProdCategories.Where(c => c.Id == addProductsVw.ProdCategory)
                .FirstOrDefaultAsync();
            products.ProductId = new Guid();
            products.ProdCategory = category;
            products.ProductName = addProductsVw.ProductName;
            products.Seller = seller;
            products.ActualPrice = addProductsVw.ActualPrice;
            products.OfferPricePrice = addProductsVw.OfferPrice;


            await _appDbContext.TblProducts.AddAsync(products);
            await _appDbContext.SaveChangesAsync();
            return new ResponseWrapper<Products>(200, "success", true, products);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}