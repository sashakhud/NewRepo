using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Dto;
using WebApplication1.Models;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.InterfaceServices
{
    public interface IOrderDetailService
    {
        public Task<IResult<List<OrderDetailDto>>> GetAllAsync();
        public Task<IResult<OrderDetailDto>> GetAsync(int DetailId);
        public Task<IResult<bool>> ExistsAsync(int DetailId);
        public Task<IResult> CreateAsync(int productId, int orderId, OrderDetailDto orderDetailCreate);
        public Task<IResult> UpdateAsync(int detailId, int orderId, int productId, OrderDetailDto updatedDetail);
        public Task<IResult> DeleteAsync(int orderDetailId);
    }
}
