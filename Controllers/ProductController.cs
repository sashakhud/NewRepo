using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Contracts.Services;
using WebApplication1.Dto;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IResult<List<ProductDto>>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }


        //[HttpGet("/GetUsersByProduct/{ProductId}")]
        /*public async Task<IResult<List<AppUserDto>>> GetCustomersByProductAsync(int ProductId)
        {
            return await _productService.GetCustomersByProductAsync(ProductId);
        }*/

        [HttpGet("{productId}")]
        public async Task<IResult<ProductDto>> GetAsync(int productId)
        {
            return await _productService.GetAsync(productId);
        }


        [HttpGet("/GetOrdersByProduct/{productId}")]
        public async Task<IResult<List<OrderDto>>> GetOrdersByProductAsync(int productId)
        {
            return await _productService.GetOrdersByProductAsync(productId);
        }


        [HttpGet("/CheckProduct/{productId}")]
        public async Task<IResult<bool>> CheckAsync(int productId)
        {
            return await _productService.ExistsAsync(productId);
        }

        [HttpPost]
        public async Task<IResult> CreateAsync([FromBody] ProductDto ProductCreate)
        {
            return await _productService.CreateAsync(ProductCreate);
        }

        [HttpPut("{productId}")]
        public async Task<IResult> UpdateAsync([FromQuery] int productId, [FromBody] ProductDto updetedProduct)
        {
            return await _productService.UpdateAsync(productId, updetedProduct);
        }

        [HttpDelete("{productId}")]
        public async Task<IResult> DeleteAsync(int productId)
        {
            return await _productService.DeleteAsync(productId);
        }
    }
}
