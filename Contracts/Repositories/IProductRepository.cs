using WebApplication1.Models;

namespace WebApplication1.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetAsync(int id);

        Task<List<Order>> GetOrderByProductAsync(int productId);

        //Task<List<AppUser>> GetCustomersByProductAsync(int productId);

        Task<int> CreateAsync(Product product);

        Task<int> UpdateAsync(Product product);

        Task<int> DeleteAsync(Product product);

        Task<int> DeleteByIdAsync(int id);

        Task<bool> ExistsAsync(int Id);
    }
}
