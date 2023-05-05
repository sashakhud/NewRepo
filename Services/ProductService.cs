using Mapster;
using MapsterMapper;
using WebApplication1.Configuration;
using WebApplication1.Contracts.Repositories;
using WebApplication1.Contracts.Services;
using WebApplication1.Dto;
using WebApplication1.Models;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository itemRepository)
        {
            _productRepository = itemRepository;
        }

        public async Task<IResult<bool>> ExistsAsync(int ProductId)
        {
            try
            {
                var check = await _productRepository.ExistsAsync(ProductId);
                return Result<bool>.Success(check);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message);
            }
        }

        public async Task<IResult> CreateAsync(ProductDto ProductCreate)
        {
            try
            {
                var create = await _productRepository.CreateAsync(ProductCreate.Adapt<Product>());
                return Result<int>.Success(create);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(int ProductId)
        {
            try
            {
                var delete = await _productRepository.DeleteByIdAsync(ProductId);
                return Result<int>.Success(delete);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }

        /*public async Task<IResult<List<AppUserDto>>> GetCustomersByProductAsync(int ProductId)
        {
            try
            {
                var customers = await _productRepository.GetCustomersByProductAsync(ProductId);
                return Result<List<AppUserDto>>.Success(customers.Adapt<List<AppUserDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<AppUserDto>>.Fail(ex);
            }
        }*/

        public async Task<IResult<List<OrderDto>>> GetOrdersByProductAsync(int ProductId)
        {
            try
            {
                var orders = await _productRepository.GetOrderByProductAsync(ProductId);
                return Result<List<OrderDto>>.Success(orders.Adapt<List<OrderDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<OrderDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult<ProductDto>> GetAsync(int ProductId)
        {
            try
            {
                var product = await _productRepository.GetAsync(ProductId);
                return Result<ProductDto>.Success(product.Adapt<ProductDto>());
            }
            catch (Exception ex)
            {
                return Result<ProductDto>.Fail(ex.Message);
            }
        }

        public async Task<IResult<List<ProductDto>>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return Result<List<ProductDto>>.Success(products.Adapt<List<ProductDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<ProductDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult> UpdateAsync(int ProductId, ProductDto updetedProduct)
        {
            try
            {
                var update = await _productRepository.UpdateAsync(updetedProduct.Adapt<Product>());
                return Result<int>.Success(update);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
