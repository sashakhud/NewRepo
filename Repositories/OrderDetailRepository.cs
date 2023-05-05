using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly Context _context;

        public OrderDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task<OrderDetail> GetAsync(int id)
        {
            return await _context.Details.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Details.AnyAsync(d => d.Id == id);
        }

        public async Task<int> CreateAsync(OrderDetail orderDetail, int productId, int orderId)
        {
            orderDetail.ProductId = productId;
            orderDetail.OrderId = orderId;
            _context.Add(orderDetail);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.Details.ToListAsync();
        }

        public async Task<int> UpdateAsync(OrderDetail orderDetail, int productId, int orderId)
        {
            orderDetail.OrderId = orderId;
            orderDetail.ProductId = productId;
            _context.Update(orderDetail);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(OrderDetail detail)
        {
            _context.Remove(detail);
            return await _context.SaveChangesAsync();
        }
    }
}