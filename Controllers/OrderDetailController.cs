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
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;


        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IResult<List<OrderDetailDto>>> GetAllAsync()
        {
            return await _orderDetailService.GetAllAsync();
        }


        [HttpGet("/GetDetail/{DetailId}")]
        public async Task<IResult<OrderDetailDto>> GetAsync(int DetailId)
        {
            return await _orderDetailService.GetAsync(DetailId);
        }


        [HttpGet("/CheckDetail/{DetailId}")]
        public async Task<IResult<bool>> ExistsAsync(int DetailId)
        {
            return await _orderDetailService.ExistsAsync(DetailId);
        }

        [HttpPost]

        public async Task<IResult> CreateAsync([FromQuery] int productId, [FromQuery] int orderId, [FromBody] OrderDetailDto orderDetailCreate)
        {
            return await _orderDetailService.CreateAsync(productId, orderId,orderDetailCreate);
        }

        [HttpPut("/UpdateDetail/{detailId}")]

        public async Task<IResult> UpdateAsync([FromQuery] int detailId, [FromQuery] int orderId, [FromQuery] int productId, [FromBody] OrderDetailDto updatedDetail)
        {
            return await _orderDetailService.UpdateAsync(detailId, orderId, productId, updatedDetail);
        }

        [HttpDelete("/DeleteOrderDetail/{detailId}")]

        public async Task<IResult> DeleteAsync(int detailId)
        {
            return await _orderDetailService.DeleteAsync(detailId);
        }
    }
}