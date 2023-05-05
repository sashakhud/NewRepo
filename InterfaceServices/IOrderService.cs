using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Dto;
using WebApplication1.Models;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.InterfaceServices
{
    public interface IOrderService
    {
        public Task<IResult<List<OrderDto>>> GetAllAsync();
        public Task<IResult<OrderDto>> GetAsync(int OrderId);
        public Task<IResult<List<ProductDto>>> GetProductsByOrder(int OrderId);
        public Task<IResult<bool>> ExistsAsync(int OrderId);
        public Task<IResult<List<OrderDetailDto>>> GetOrderDetailsAsync(int OrderId);
        public Task<IResult> CreateAsync(string customerId, OrderDto orderCreate);
        public Task<IResult> UpdateAsync(int OrderId, string CustomerId, OrderDto UpdatedOrder);
        public Task<IResult> DeleteAsync(int OrderId);
    }
}
