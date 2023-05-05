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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IResult<bool>> ExistsAsync(int OrderId)
        {
            try
            {
                var check = await _orderRepository.ExistsAsync(OrderId);
                return Result<bool>.Success(check);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message);
            }
        }

        public async Task<IResult> CreateAsync(string customerId, OrderDto orderCreate)
        {
            try
            {
                var create = await _orderRepository.CreateAsync(customerId, orderCreate.Adapt<Order>());
                return Result<int>.Success(create);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }

        public async Task<IResult> DeleteAsync(int OrderId)
        {
            try
            {
                var delete = await _orderRepository.DeleteByIdAsync(OrderId);
                return Result<int>.Success(delete);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }

        public async Task<IResult<OrderDto>> GetAsync(int OrderId)
        {
            try
            {
                var order = await _orderRepository.GetAsync(OrderId);
                return Result<OrderDto>.Success(order.Adapt<OrderDto>());
            }
            catch (Exception ex)
            {
                return Result<OrderDto>.Fail(ex.Message);
            }
        }

        public async Task<IResult<List<OrderDto>>> GetAllAsync()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync();
                return Result<List<OrderDto>>.Success(orders.Adapt<List<OrderDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<OrderDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult<List<ProductDto>>> GetProductsByOrder(int OrderId)
        {
            try
            {
                var productsByOrder = await _orderRepository.GetProductByOrderAsync(OrderId);
                return Result<List<ProductDto>>.Success(productsByOrder.Adapt<List<ProductDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<ProductDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult> UpdateAsync(int OrderId, string CustomerId, OrderDto UpdatedOrder)
        {
            try
            {
                var update = await _orderRepository.UpdateAsync(CustomerId, UpdatedOrder.Adapt<Order>());
                return Result<int>.Success(update);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
