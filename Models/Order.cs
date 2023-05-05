using WebApplication1.Enum;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<OrderDetail>? Details { get; set; } = new List<OrderDetail>();
    }
}