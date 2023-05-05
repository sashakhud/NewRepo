using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductDto? Product { get; set; }
    }
}
