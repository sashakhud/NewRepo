using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _context.AppUsers.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<AppUser> GetAsync(string id)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.AppUsers.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _context.Orders.Where(o => o.AppUserId == customerId).ToListAsync();
        }

        public async Task<int> CreateAsync(AppUser customer)
        {
            _context.Add(customer);
            return await _context.SaveChangesAsync();
        }


        public async Task<int> UpdateAsync(AppUser customer)
        {
            _context.Update(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(AppUser customer)
        {
            _context.AppUsers.Remove(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(string id)
        {
            var appUser = await _context.AppUsers
                .FirstOrDefaultAsync(a => a.Id == id);
            _context.AppUsers.Remove(appUser);
            return await _context.SaveChangesAsync();
        }
    }
}