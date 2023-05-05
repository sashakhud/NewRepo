using WebApplication1.Configuration;
using WebApplication1.Dto;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Contracts.Services
{
    public interface IAppUserService
    {
        public Task<IResult<List<AppUserDto>>> GetAllAsync();
        public Task<IResult<List<OrderDto>>> GetOrderByCustomerAsync(string CustomerId);
        public Task<IResult<AppUserDto>> GetAsync(string CustomerId);
        public Task<IResult<bool>> ExistsAsync(string CustomerId);
        public Task<IResult> UpdateAsync(string customerId, AppUserDto updatedCustomer);
        public Task<IResult> DeleteAsync(string CustomerId);
        public Task<IResult> CreateAsync(UserRegistrationRequestDto request);
        public Task<IResult<string>> GetTokenAsync(UserLoginRequestDto request);


    }
}
