using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderDetailDto>? Details { get; set; } = new List<OrderDetailDto>();
    }
}
