using WebApplication1.Models;

namespace WebApplication1.Contracts.Repositories
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetAllAsync();

        Task<AppUser> GetAsync(string id);

        Task<List<Order>> GetOrdersByCustomerAsync(string customerId);

        Task<int> CreateAsync(AppUser customer);

        Task<int> UpdateAsync(AppUser customer);

        Task<int> DeleteAsync(AppUser customer);

        Task<int> DeleteByIdAsync(string id);

        Task<bool> ExistsAsync(string id);
    }
}
