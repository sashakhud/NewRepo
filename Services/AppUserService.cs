using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Configuration;
using WebApplication1.Contracts.Repositories;
using WebApplication1.Contracts.Services;
using WebApplication1.Dto;
using WebApplication1.Models;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _customerRepository;
        private readonly JwtConfig _jwtConfig;
        private readonly UserManager<AppUser> _userManager;
        public AppUserService(IAppUserRepository customerRepository, IOptions<JwtConfig> jwtOptions,
                                        UserManager<AppUser> userManager)
        {
            _customerRepository = customerRepository;
            _jwtConfig = jwtOptions.Value;
            _userManager = userManager;
        }


        public async Task<IResult<bool>> ExistsAsync(string customerId)
        {
            try
            {
                var exists = await _customerRepository.ExistsAsync(customerId);
                return Result<bool>.Success(exists);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(string customerId)
        {
            try
            {
                var delete = await _customerRepository.DeleteByIdAsync(customerId);
                return Result<int>.Success(delete);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }

        public async Task<IResult<AppUserDto>> GetAsync(string customerId)
        {
            try
            {
                var customer = await _customerRepository.GetAsync(customerId);
                return Result<AppUserDto>.Success(customer.Adapt<AppUserDto>());
            }
            catch (Exception ex)
            {
                return Result<AppUserDto>.Fail(ex.Message);
            }

        }

        public async Task<IResult<List<AppUserDto>>> GetAllAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                return Result<List<AppUserDto>>.Success(customers.Adapt<List<AppUserDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<AppUserDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult<List<OrderDto>>> GetOrderByCustomerAsync(string CustomerId)
        {
            try
            {
                var orders = await _customerRepository.GetOrdersByCustomerAsync(CustomerId);
                return Result<List<OrderDto>>.Success(orders.Adapt<List<OrderDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<OrderDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult> UpdateAsync(string customerId, AppUserDto updatedCustomer)
        {
            try
            {
                var customer = await _customerRepository.UpdateAsync(updatedCustomer.Adapt<AppUser>());
                return Result<int>.Success(customer);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
        public async Task<IResult> CreateAsync(UserRegistrationRequestDto request)
        {


            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return Result.Fail("Email is used");
            }

            var newUser = new AppUser() { Email = request.Email, UserName = request.Username };
            var isCreated = await _userManager.CreateAsync(newUser, request.Password);
            if (isCreated.Succeeded)
            {
                return Result.Success();
            }

            return Result.Fail("");

        }

        public async Task<IResult<string>> GetTokenAsync(UserLoginRequestDto request)
        {

            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser == null)
            {
                return Result<string>.Fail("Invalid email");
            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);

            if (!isCorrect)
            {
                return Result<string>.Fail("");
            }

            var jwtToken = GenerateJwtToken(existingUser);

            return Result<string>.Success(jwtToken);

        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var expirationtime = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
        expires: expirationtime, signingCredentials: creds);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
