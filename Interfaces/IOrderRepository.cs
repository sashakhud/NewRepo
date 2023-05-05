using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<List<OrderDetail>> GetOrderDetailsAsync(int id);

        Task<Order> GetAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<int> CreateAsync(string CustomerId, Order order);

        Task<int> UpdateAsync(string CustomerId, Order order);

        Task<int> DeleteAsync(Order Order);

        Task<List<Product>> GetProductByOrderAsync(int OrderId);
    }
}
