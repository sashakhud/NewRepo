using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.InterfaceServices;
using WebApplication1.Models;
using WebApplication1.Services;
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


        [HttpGet("/GetUsersByProduct/{ProductId}")]
        /*public async Task<IResult<List<AppUserDto>>> GetCustomersByProductAsync(int ProductId)
        {
            return await _productService.GetCustomersByProductAsync(ProductId);
        }*/

        [HttpGet("/GetProduct/{ProductId}")]
        public async Task<IResult<ProductDto>> GetAsync(int ProductId)
        {
            return await _productService.GetAsync(ProductId);
        }


        [HttpGet("/GetOrdersByProduct/{ProductId}")]
        public async Task<IResult<List<OrderDto>>> GetOrdersByProductAsync(int ProductId)
        {
            return await _productService.GetOrdersByProductAsync(ProductId);
        }


        [HttpGet("/CheckProduct/{ProductId}")]
        public async Task<IResult<bool>> CheckAsync(int ProductId)
        {
            return await _productService.ExistsAsync(ProductId);
        }

        [HttpPost]
        public async Task<IResult> CreateAsync([FromBody] ProductDto ProductCreate)
        {
            return await _productService.CreateAsync(ProductCreate);
        }

        [HttpPut("/UpdateProduct/{ProductId}")]
        public async Task<IResult> UpdateAsync([FromQuery] int ProductId, [FromBody] ProductDto updetedProduct)
        {
            return await _productService.UpdateAsync(ProductId, updetedProduct);
        }

        [HttpDelete("/DeleteProduct/{ProductId}")]
        public async Task<IResult> DeleteAsync(int ProductId)
        {
            return await _productService.DeleteAsync(ProductId);
        }
    }
}
