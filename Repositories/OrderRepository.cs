using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductByOrderAsync(int OrderId)
        {
            var products = from product in _context.Products
                           join detail in _context.Details on product.Id equals detail.ProductId
                           join order in _context.Orders on detail.OrderId equals order.Id
                           where order.Id == OrderId
                           select product;
            return await products.ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.OrderBy(o => o.Id).ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Orders.AnyAsync(o => o.Id == id);
        }

        public async Task<int> CreateAsync(string CustomerId, Order order)
        {
            order.AppUserId = CustomerId;
            _context.Add(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(string CustomerId, Order order)
        {
            order.AppUserId = CustomerId;
            _context.Update(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Order Order)
        {
            _context.Orders.Remove(Order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync();
        }
    }
}