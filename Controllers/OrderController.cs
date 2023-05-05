
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
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<IResult<List<OrderDto>>> GetAllAsync()
        {
            return await _orderService.GetAllAsync();
        }


        [HttpGet("/GetOrder/{OrderId}")]
        public async Task<IResult<OrderDto>> GetAsync(int OrderId)
        {
            return await _orderService.GetAsync(OrderId);
        }


        [HttpGet("/GetItemsInOrder/{OrderId}")]
        public async Task<IResult<List<ProductDto>>> GetProductsByOrderAsync(int OrderId)
        {
            return await _orderService.GetProductsByOrder(OrderId);
        }

        [HttpGet("/CheckOrder/{OrderId}")]
        public async Task<IResult<bool>> ExistsAsync(int OrderId)
        {
            return await _orderService.ExistsAsync(OrderId);
        }

        [HttpGet("/GetOrderDetails/{OrderId}")]
        public async Task<IResult<List<OrderDetailDto>>> GetOrderDetailsAsync(int OrderId)
        {
            return await _orderService.GetOrderDetailsAsync(OrderId);
        }


        [HttpPost]
        public async Task<IResult> CreateAsync([FromQuery] string customerId, [FromBody] OrderDto orderCreate)
        {
            return await _orderService.CreateAsync(customerId, orderCreate);
        }

        [HttpPut("/UpdateOrder/{OrderId}")]
        public async Task<IResult> UpdateAsync([FromQuery] int OrderId, [FromQuery] string CustomerId, OrderDto UpdatedOrder)
        {
            return await _orderService.UpdateAsync(OrderId, CustomerId, UpdatedOrder);
        }

        [HttpDelete("/DeleteOrder/{OrderId}")]
        public async Task<IResult> DeleteAsync(int OrderId)
        {
            return await _orderService.DeleteAsync(OrderId);
        }
    }
}
