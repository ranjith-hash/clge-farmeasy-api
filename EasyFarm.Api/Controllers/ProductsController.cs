    using EasyFarm.Api.Entities;
    using EasyFarm.Api.Helpers;
    using EasyFarm.Api.Services.Ecom;
    using EasyFarm.Api.Views;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace EasyFarm.Api.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IProductService _productService;

            public ProductsController(IProductService productService)
            {
                _productService = productService;
            }

            [HttpPost("category")]
            public async Task<ResponseWrapper<ProdCategory>> PostProdCategory(ProdCategory prodCategory)
            {
                var prodData = await _productService.AddCategory(prodCategory);

                return new ResponseWrapper<ProdCategory>(prodData.StatusCode, prodData.Message, prodData.Sucess, prodData.ApiData);
            }

        
        
        [HttpGet("type")]
        public async Task<ResponseWrapper<List<SellingProducts>>> GetExample([FromQuery] string category)
        {
            ProdCategoryVw productsCategories = new ProdCategoryVw();
            productsCategories.Category = category;
            var productsData = await _productService.GetSellingProducts(productsCategories);

            return new ResponseWrapper<List<SellingProducts>>(productsData.StatusCode, productsData.Message,
                productsData.Sucess, productsData.ApiData);
        }


        [HttpPost("AddToCart")]
        public async Task<ResponseWrapper<CartList>> AddToCart(AddToCartVw addToCartVw)
        {
           var resp = await _productService.AddToCart(addToCartVw);
           return resp;
        }

        [HttpPost("GetCartItems")]
        public async Task<ResponseWrapper<List<CartList>>> GetItemsInCart(UserEmail email )
        {
            var resp = await _productService.GetCartItem(email.Email);
            return resp;
        }

        [HttpDelete("removecartitem")]
        public async Task<ResponseWrapper<CartList>> RemoveCartItem(int id)
        {
            var resp = await _productService.RemoveFromCart(id);
            return resp;
        }

        [HttpPost("addOrders")]
        public async Task<ResponseWrapper<OrdersVw>> AddOrders(OrdersVw ordersVws)
        {
            var resp = await _productService.AddOrders(ordersVws);
            return resp;
        }

        [HttpPost("allOrders")]
        public async Task<ResponseWrapper<List<Orders>>> GetAllOrders(UserEmail email)
        {
            var resp = await _productService.GetAllOrders(email.Email);
            return resp;
        }
    }
}
