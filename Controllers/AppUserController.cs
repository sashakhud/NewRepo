using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Contracts.Services;
using WebApplication1.Dto;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _customerService;

        public AppUserController(IAppUserService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<IResult<List<AppUserDto>>> GetAllAsync()
        {
            return await _customerService.GetAllAsync();
        }

        [HttpGet("/GetOrdersByAppUser/{appUserId}")]
        public async Task<IResult<List<OrderDto>>> GetOrderByCustomerAsync(string appUserId)
        {
            return await _customerService.GetOrderByCustomerAsync(appUserId);
        }



        [HttpGet("/GetAppUser/{appUserId}")]
        public async Task<IResult<AppUserDto>> GetAsync(string appUserId)
        {
            return await _customerService.GetAsync(appUserId);
        }

        [HttpGet("{appUserId}")]
        public async Task<IResult<bool>> ExistsAsync(string appUserId)
        {
            return await _customerService.ExistsAsync(appUserId);
        }


        [HttpPost]
        public async Task<IResult> CreateAsync(UserRegistrationRequestDto customerCreate)
        {
            return await _customerService.CreateAsync(customerCreate);
        }

        [HttpPut("{appUserId}")]

        public async Task<IResult> UpdateAsync([FromQuery] string appUserId, [FromBody] AppUserDto updatedCustomer)
        {
            return await _customerService.UpdateAsync(appUserId, updatedCustomer);
        }

        [HttpDelete("{appUserId}")]
        public async Task<IResult> DeleteAsync(string appUserId)
        {
            return await _customerService.DeleteAsync(appUserId);
        }


        [HttpPost("Login")]
        public async Task<IResult<string>> PostLogin(UserLoginRequestDto request)
        {

            return await _customerService.GetTokenAsync(request);
        }
    }
}