using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Services.Seller;
using EasyFarm.Api.Views;
using Microsoft.AspNetCore.Mvc;

namespace EasyFarm.Api.Controllers;

[ApiController]
[Route("api/seller")]
public class SellerController : Controller
{
    private readonly ISellerService _sellerService;

    public SellerController(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }
    // GET
    [HttpPost("orders")]
    public async Task<ResponseWrapper<List<GetSellerOrders>>> GetSellerOrders(UserEmail userEmail)
    {
        var sellerOrders = await _sellerService.GetSellerOrder(userEmail);
        return sellerOrders;
    }

    [HttpPost("get-products")]
    public async Task<ResponseWrapper<List<Products>>> GetProducts(UserEmail sellerEmail)
    {
        var resp = await _sellerService.GetSellerProducts(sellerEmail);
        return resp;
    }
    
    [HttpPost("add-products")]
    public async Task<ResponseWrapper<Products>> AddProducts(AddProductsVw productsVw)
    {
        var resp = await _sellerService.AddSellerProducts(productsVw);
        return resp;
    }

    [HttpGet("getCategories")]
    public async Task<ResponseWrapper<List<ProdCategory>>> GetProdCategory()
    {
        var resp = await _sellerService.GetCategoryies();
        return resp;
    }
}