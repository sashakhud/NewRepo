using Mapster;
using MapsterMapper;
using WebApplication1.Configuration;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.InterfaceServices;
using WebApplication1.Models;
using WebApplication1.Repositories;
using IResult = WebApplication1.Configuration.IResult;

namespace WebApplication1.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IResult<bool>> ExistsAsync(int DetailId)
        {
            try
            {
                var exists = await _orderDetailRepository.ExistsAsync(DetailId);
                return Result<bool>.Success(exists);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message);
            }
        }

        public async Task<IResult> CreateAsync(int productId, int orderId, OrderDetailDto orderDetailCreate)
        {
            try
            {
                var create = await _orderDetailRepository.CreateAsync(orderDetailCreate.Adapt<OrderDetail>(), productId, orderId);
                return Result<int>.Success(create);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }

        }

        public async Task<IResult> DeleteAsync(int orderDetailId)
        {
            try
            {
                var orderDetailToDelete = await _orderDetailRepository.GetAsync(orderDetailId);
                var delete = await _orderDetailRepository.DeleteAsync(orderDetailToDelete);
                return Result<int>.Success(delete);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }

        public async Task<IResult<OrderDetailDto>> GetAsync(int DetailId)
        {
            try
            {
                var detail = await _orderDetailRepository.GetAsync(DetailId);
                return Result<OrderDetailDto>.Success(detail.Adapt<OrderDetailDto>());
            }
            catch (Exception ex)
            {
                return Result<OrderDetailDto>.Fail(ex.Message);
            }
        }

        public async Task<IResult<List<OrderDetailDto>>> GetAllAsync()
        {
            try
            {
                var details = await _orderDetailRepository.GetAllAsync();
                return Result<List<OrderDetailDto>>.Success(details.Adapt<List<OrderDetailDto>>());
            }
            catch (Exception ex)
            {
                return Result<List<OrderDetailDto>>.Fail(ex.Message);
            }
        }

        public async Task<IResult> UpdateAsync(int detailId, int orderId, int productId, OrderDetailDto updatedDetail)
        {
            try
            {
                var detail = await _orderDetailRepository.UpdateAsync(updatedDetail.Adapt<OrderDetail>(), productId, orderId);
                return Result<int>.Success(detail);
            }
            catch (Exception ex)
            {
                return Result<int>.Fail(ex.Message);
            }
        }
    }
}
