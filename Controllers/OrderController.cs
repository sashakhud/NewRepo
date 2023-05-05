using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Contracts.Services;
using WebApplication1.Dto;
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


        [HttpGet("{orderId}")]
        public async Task<IResult<OrderDto>> GetAsync(int orderId)
        {
            return await _orderService.GetAsync(orderId);
        }


        [HttpGet("/GetItemsInOrder/{orderId}")]
        public async Task<IResult<List<ProductDto>>> GetProductsByOrderAsync(int orderId)
        {
            return await _orderService.GetProductsByOrder(orderId);
        }

        [HttpGet("/CheckOrder/{orderId}")]
        public async Task<IResult<bool>> ExistsAsync(int orderId)
        {
            return await _orderService.ExistsAsync(orderId);
        }


        [HttpPost]
        public async Task<IResult> CreateAsync([FromQuery] string appUserId, [FromBody] OrderDto orderCreate)
        {
            return await _orderService.CreateAsync(appUserId, orderCreate);
        }

        [HttpPut("{orderId}")]
        public async Task<IResult> UpdateAsync([FromQuery] int orderId, [FromQuery] string customerId, OrderDto updatedOrder)
        {
            return await _orderService.UpdateAsync(orderId, customerId, updatedOrder);
        }

        [HttpDelete("{orderId}")]
        public async Task<IResult> DeleteAsync(int orderId)
        {
            return await _orderService.DeleteAsync(orderId);
        }
    }
}
