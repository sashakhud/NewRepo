using Microsoft.AspNetCore.Mvc;
using WebApplication1.Configuration;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.InterfaceServices;
using WebApplication1.Models;
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

        [HttpGet("/GetOrdersByAppUser/{AppUserId}")]
        public async Task<IResult<List<OrderDto>>> GetOrderByCustomerAsync(string AppUserId)
        {
            return await _customerService.GetOrderByCustomerAsync(AppUserId);
        }



        [HttpGet("/GetAppUser/{AppUserId}")]
        public async Task<IResult<AppUserDto>> GetAsync(string AppUserId)
        {
            return await _customerService.GetAsync(AppUserId);
        }

        [HttpGet("/CheckAppUser/{AppUserId}")]
        public async Task<IResult<bool>> ExistsAsync(string AppUserId)
        {
            return await _customerService.ExistsAsync(AppUserId);
        }


        [HttpPost]
        public async Task<IResult> CreateAsync(UserRegistrationRequestDto customerCreate)
        {
            return await _customerService.CreateAsync(customerCreate);
        }

        [HttpPut("/UpdateAppUser/{AppUserId}")]

        public async Task<IResult> UpdateAsync([FromQuery] string AppUserId, [FromBody] AppUserDto updatedCustomer)
        {
            return await _customerService.UpdateAsync(AppUserId, updatedCustomer);
        }

        [HttpDelete("/DeleteAppUser/{AppUserId}")]
        public async Task<IResult> DeleteAsync(string AppUserId)
        {
            return await _customerService.DeleteAsync(AppUserId);
        }


        [HttpPost("Login")]
        public async Task<IResult<string>> PostLogin(UserLoginRequestDto request)
        {

            return await _customerService.GetTokenAsync(request);
        }
    }
}