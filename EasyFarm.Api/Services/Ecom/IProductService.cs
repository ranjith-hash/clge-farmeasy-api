using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Views;

namespace EasyFarm.Api.Services.Ecom;

public interface IProductService
{
    Task<ResponseWrapper<List<SellingProducts>>> GetSellingProducts(ProdCategoryVw productsCategories);
    Task<ResponseWrapper<ProdCategory>> AddCategory(ProdCategory prodCategory);
    
    Task<ResponseWrapper<CartList>> AddToCart(AddToCartVw addToCartVw);

    Task<ResponseWrapper<List<CartList>>> GetCartItem(string email);

    Task<ResponseWrapper<CartList>> RemoveFromCart(int id);

    Task<ResponseWrapper<OrdersVw>> AddOrders(OrdersVw ordersVws);
    
    Task<ResponseWrapper<List<Orders>>> GetAllOrders(string email);

}