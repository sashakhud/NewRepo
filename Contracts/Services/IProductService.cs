using WebApplication1.Configuration;
using WebApplication1.Dto;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Contracts.Services
{
    public interface IProductService
    {
        public Task<IResult<List<ProductDto>>> GetAllAsync();
        //public Task<IResult<List<AppUserDto>>> GetCustomersByProductAsync(int ProductId);
        public Task<IResult<ProductDto>> GetAsync(int ProductId);
        public Task<IResult<List<OrderDto>>> GetOrdersByProductAsync(int ProductId);
        public Task<IResult<bool>> ExistsAsync(int ProductId);
        public Task<IResult> CreateAsync(ProductDto ProductCreate);
        public Task<IResult> UpdateAsync(int ProductId, ProductDto updetedProduct);
        public Task<IResult> DeleteAsync(int ProductId);
    }
}
