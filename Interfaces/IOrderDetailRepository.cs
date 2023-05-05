using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetAsync(int id);

        Task<List<OrderDetail>> GetAllAsync();

        Task<int> CreateAsync(OrderDetail orderDetail, int itemId, int orderId);

        Task<int> UpdateAsync(OrderDetail orderDetail, int itemId, int orderId);

        Task<int> DeleteAsync(OrderDetail detail);

        Task<bool> ExistsAsync(int id);
    }
}
