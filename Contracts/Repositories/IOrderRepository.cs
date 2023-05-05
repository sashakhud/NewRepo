using WebApplication1.Models;

namespace WebApplication1.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<int> CreateAsync(string CustomerId, Order order);

        Task<int> UpdateAsync(string CustomerId, Order order);

        Task<int> DeleteAsync(Order Order);
        Task<int> DeleteByIdAsync(int id);

        Task<List<Product>> GetProductByOrderAsync(int OrderId);
    }
}
