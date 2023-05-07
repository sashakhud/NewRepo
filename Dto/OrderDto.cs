using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public List<CreateOrderDetailRequestDto> OrderDetails { get; set; }
    }
}
