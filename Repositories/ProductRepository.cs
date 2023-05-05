using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        /*public async Task<List<AppUser>> GetCustomersByProductAsync(int ProductId)
        {
            var customers = from customer in _context.AppUsers
                            join order in _context.Orders on customer.Id equals order.AppUserId
                            join detail in _context.Details on order.Id equals detail.OrderId
                            where detail.ProductId == ProductId
                            select customer;
            return await customers.ToListAsync();
        }*/

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.OrderBy(i => i.Id).ToListAsync();
        }

        public async Task<List<Order>> GetOrderByProductAsync(int ProductId)
        {
            var orders = from order in _context.Orders
                         join detail in _context.Details on order.Id equals detail.OrderId
                         where detail.ProductId == ProductId
                         select order;
            return await orders.ToListAsync();
        }

        public async Task<bool> ExistsAsync(int Id)
        {
            return await _context.Products.AnyAsync(i => i.Id == Id);
        }

        public async Task<int> CreateAsync(Product product)
        {
            _context.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Product product)
        {
            _context.Update(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }
    }
}